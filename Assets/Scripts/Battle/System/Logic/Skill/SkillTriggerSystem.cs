using System;
using Battle.Trigger;

namespace Battle
{
    public class SkillTriggerSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _actionQuery;
        private EntityQuery _boundsQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _actionQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(TriggerAction)}
            });
            _boundsQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(TriggerBounds), typeof(Bounds)}
            });
        }

        public override void Update(int step)
        {
            _actionQuery.GetEntityIdList().ForEach(ActionTrigger);
            _boundsQuery.GetEntityIdList().ForEach(BoundsTrigger);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_actionQuery.desc);
            _entityManager.RemoveWithComponent(_boundsQuery.desc);
        }

        private void ActionTrigger(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (skillBase.IsTriggerOver)
            {
                // 触发已结束
                return;
            }

            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }

            var action = _entityManager.GetComponent<Action>(skillBase.Release);

            var triggerAction = _entityManager.GetComponent<TriggerAction>(entityId);
            if (!triggerAction.IsSetAction)
            {
                // 设置施法者动作
                action.TriggerAttack = triggerAction.AttackAction;
                triggerAction.IsSetAction = true;
            }

            if (action.CurAttack.Attack != triggerAction.AttackAction)
            {
                return;
            }

            if (action.CurAttack.CurFrame >= action.CurAttack.EventFrame)
            {
                // 触发动作事件帧
                skillBase.IsTakeEffect = true;
            }

            if (action.CurAttack.CurFrame >= action.CurAttack.Frame)
            {
                // 触发结束
                skillBase.IsTriggerOver = true;
                triggerAction.IsSetAction = false;
            }
        }

        private void BoundsTrigger(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (skillBase.IsTriggerOver)
            {
                // 触发已结束
                return;
            }
            
            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }
            
            var triggerBounds = _entityManager.GetComponent<TriggerBounds>(entityId);
            var bounds = _entityManager.GetComponent<Bounds>(entityId);
            var maxCount = Math.Min(bounds.EntityList.Count, triggerBounds.TargetCount);
            if (triggerBounds.IsHaveTargetTrigger && maxCount <= 0)
            {
                // 需要有目标才触发
                return;
            }
            for (int i = 0; i < maxCount; i++)
            {
                skillBase.TargetList.Add(bounds.EntityList[i]);
            }

            // 触发完毕
            skillBase.IsTakeEffect = true;
            skillBase.IsTriggerOver = true;
        }
    }
}