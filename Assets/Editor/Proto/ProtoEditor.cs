using System.Diagnostics;
using System.IO;
using Excel;
using Google.Protobuf;
using System;
using UnityEditor;
using UnityEngine;

namespace Proto
{
    public class ProtoEditor : Editor
    {
        private static ProtoEditorConfig _configInstance;
        private static ProtoEditorConfig config
        {
            get
            {
                if (_configInstance == null)
                {
                    _configInstance = CreateInstance<ProtoEditorConfig>();
                }

                return _configInstance;
            }
        }

        [MenuItem("Tools/DataTable/ExcelToProtoCsharp", false)]
        public static void ExcelToProtoCsharp()
        {
            ExcelToProto();
            ProtoToCsharp();
            AssetDatabase.Refresh();
        }

        private static void ExcelToProto()
        {
            var path = config.tableExcelPath;
            if (!Directory.Exists(path))
            {
                return;
            }

            var dir = new DirectoryInfo(path);
            var allFiles = dir.GetFileSystemInfos("*.xlsx", SearchOption.AllDirectories);

            foreach (var fileSystemInfo in allFiles)
            {
                var stream = File.Open(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = excelReader.AsDataSet();
                var table = result.Tables[0];
                if (table.Rows.Count < 3)
                {
                    continue;
                }

                var className = fileSystemInfo.Name.Replace(fileSystemInfo.Extension, "");

                var data = "{\n";
                var valueTypes = table.Rows[1].ItemArray;
                var keys = table.Rows[2].ItemArray;
                for (var i = 0; i < keys.Length; i++)
                {
                    var key = keys[i];
                    if (key == null || string.IsNullOrEmpty(key.ToString()))
                    {
                        continue;
                    }
                    data += $"\t{valueTypes[i]} {keys[i]} = {i + 1};\n";
                }

                data += "}";

                var tableStr = "{\n" + $"\trepeated {className}Data Table = 1;\n" + "}";

                var syntax = "\"proto3\"";
                
                var proto = $@"syntax = {syntax};

package ProtoDataTable;

message {className}Data{data}

message {className}Table{tableStr}";

                var fullPath = config.tableProtoPath + fileSystemInfo.Name.Replace(fileSystemInfo.Extension, ".proto");
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                var writer = File.CreateText(fullPath);

                writer.Write(proto);
                writer.Close();
                writer.Dispose();
            }
        }

        private static void ProtoToCsharp()
        {
            var path = config.tableProtoPath;
            if (!Directory.Exists(path))
            {
                return;
            }

            var dir = new DirectoryInfo(path);
            var allFiles = dir.GetFileSystemInfos("*.proto", SearchOption.AllDirectories);
            foreach (var fileSystemInfo in allFiles)
            {
                var arguments = $"-I={path} --csharp_out={config.protoCsharpPath} {fileSystemInfo.Name.Replace(fileSystemInfo.Extension, ".proto")}";
                
#if UNITY_EDITOR_WIN
                Process.Start($"{Application.dataPath}/../Tools/Proto/windows_x86/protoc.exe", arguments);          
#endif

#if UNITY_EDITOR_OSX
                Process.Start($"{Application.dataPath}/../Tools/Proto/macosx_x64/protoc", arguments);
#endif
            }
        }

        [MenuItem("Tools/DataTable/ExcelToProtoData", false)]
        public static void ExcelToProtoData()
        {
            var path = config.tableExcelPath;
            if (!Directory.Exists(path))
            {
                return;
            }

            var dir = new DirectoryInfo(path);
            var allFiles = dir.GetFileSystemInfos("*.xlsx", SearchOption.AllDirectories);

            foreach (var fileSystemInfo in allFiles)
            {
                var stream = File.Open(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = excelReader.AsDataSet();
                var table = result.Tables[0];
                if (table.Rows.Count < 4)
                {
                    continue;
                }

                var className = fileSystemInfo.Name.Replace(fileSystemInfo.Extension, "");

                var keys = table.Rows[2].ItemArray;

                var tableDataType = Type.GetType($"ProtoDataTable.{className}Table, Assembly-CSharp");
                var dataType = Type.GetType($"ProtoDataTable.{className}Data, Assembly-CSharp");

                var tableData = Activator.CreateInstance(tableDataType);
                var dataList = tableDataType.GetMethod("get_Table").Invoke(tableData, null);
                var addData = dataList.GetType().GetMethod("Add", new[] {dataType});

                for (var i = 3; i < table.Rows.Count; i++) 
                {
                    var data = Activator.CreateInstance(dataType);

                    var values = table.Rows[i].ItemArray;
                    for (var j = 0; j < values.Length; j++)
                    {
                        var keyObj = keys[j];
                        var valueObj = values[j];
                        if (keyObj == null || string.IsNullOrEmpty(keyObj.ToString()) || valueObj == null || string.IsNullOrEmpty(valueObj.ToString()))
                        {
                            continue;
                        }

                        var key = keyObj.ToString();
                        var set = dataType.GetMethod($"set_{key[0].ToString().ToUpper() + key.Substring(1)}");
                        var value = Convert.ChangeType(valueObj, set.GetParameters()[0].ParameterType);
                        set.Invoke(data, new[] {value});
                    }

                    addData.Invoke(dataList, new[] {data});
                }

                using (var output = File.Create($"{config.protoDataPath}/{className}"))
                {
                    var codedOutput = new CodedOutputStream(output);
                    tableDataType.GetMethod("WriteTo").Invoke(tableData, new object[] {codedOutput});
                    codedOutput.Flush();
                }
            }
        }
    }
}