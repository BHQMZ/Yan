using System.Collections.Generic;

namespace Battle
{
    public class Action : Component
    {
        // 动作名
        public int actionName;
        // 动作帧
        public int actionFrame;
        // 触发帧
        public List<int> triggerFrameList;
        // 帧事件
        // public List<int> 
        // 当前帧
        public int curFrame;
    }
}