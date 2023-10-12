using System.Collections.Generic;

namespace Battle
{
    public class Action : Component
    {
        // 动作名
        public string ActionName;
        // 当前数据
        public ActionData CurData;
        // 当前帧
        public int CurFrame;
        // 动作数据列表
        public readonly List<ActionData> ActionDataList = new();
    }

    public struct ActionData
    {
        // 动作名
        public string Name;
        // 总帧
        public int Frame;
        // 事件帧
        public int EventFrame;
        // 是否循环
        public bool IsLoop;
    }
}