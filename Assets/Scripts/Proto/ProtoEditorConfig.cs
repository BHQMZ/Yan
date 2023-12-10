using System;
using UnityEditor;
using UnityEngine;

namespace Proto
{
    [Serializable]
    public class ProtoEditorConfig : ScriptableObject
    {
        public DefaultAsset tableExcelFolder;
        public DefaultAsset tableProtoFolder;
        public DefaultAsset protoCsharpFolder;
        public DefaultAsset protoDataFolder;
        public DefaultAsset networkProtoFolder;
        public DefaultAsset networkCsharpFolder;

        public string tableExcelPath => AssetDatabase.GetAssetPath(tableExcelFolder) + "/";
        public string tableProtoPath => AssetDatabase.GetAssetPath(tableProtoFolder) + "/";
        public string protoCsharpPath => AssetDatabase.GetAssetPath(protoCsharpFolder) + "/";
        public string protoDataPath => AssetDatabase.GetAssetPath(protoDataFolder) + "/";
        public string networkProtoPath => AssetDatabase.GetAssetPath(networkProtoFolder) + "/";
        public string networkCsharpPath => AssetDatabase.GetAssetPath(networkCsharpFolder) + "/";
    }
}