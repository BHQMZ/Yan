using System.Collections.Generic;

namespace Battle
{
    /// <summary>
    /// 技能基础组件
    /// </summary>
    public class SkillBase : Component
    {
        // 释放目标
        public int release;
        // 指定目标队列
        public List<int> targetList = new();
        // 效果命令
        public string command;
        // 是否执行完命令
        public bool isOverCommand;
        // 效果列表
        public int effectId;
    }
}