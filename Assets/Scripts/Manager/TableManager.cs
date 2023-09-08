using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Google.Protobuf;
using Google.Protobuf.Collections;
using UnityEngine.Device;

namespace Manager
{
    public class TableManager
    {
        private static readonly Dictionary<string, IMessage> _tableDataMap = new Dictionary<string, IMessage>();
    
        public static T GetTable<T>() where T : IMessage<T>
        {
            T data;
            var type = typeof(T);
            var typeName = type.FullName;
            if (_tableDataMap.ContainsKey(typeName))
            {
                return (T) _tableDataMap[typeName];
            }

            using (var input =
                   File.OpenRead($"{Application.dataPath}/Proto/ProtoData/{type.Name.Replace("Table", "")}"))
            {
                var parser = (MessageParser) type.InvokeMember("get_Parser",
                    BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, null);
                data = (T) parser.ParseFrom(input);
            }

            _tableDataMap[typeName] = data;
            return data;
        }
        
        public TD GetDataById<T, TD>(int id) where T : IMessage<T> where TD : IMessage<T>
        {
            var type = typeof(TD);
            var getId = type.GetMethod("get_Id");
            if (getId == null)
            {
                return default;
            }
            var table = GetTable<T>();
            var dataList = (RepeatedField<TD>) typeof(T).GetMethod("get_Table").Invoke(table, null);
            foreach (var message in dataList)
            {
                if (Convert.ToInt32(getId.Invoke(message, null)) == id)
                {
                    return message;
                }
            }

            return default;
        }
    }
}