using UnityEngine;

namespace Battle
{
    public class CharacterManager
    {
        public static int CreateHero(EntityManager entityManager)
        {
            var player = entityManager.CreateEntity();
            entityManager.AddComponent(player, new Transform());
            entityManager.AddComponent(player, new Ball
            {
                Radius = 5,
                Offset = new Vector3(0, 4.5f, 0)
            });
            entityManager.AddComponent(player, new Character());
            entityManager.AddComponent(player, new Hero());
            entityManager.AddComponent(player, new AnimatorControl());
            entityManager.AddComponent(player, new PlayerControl());
            entityManager.AddComponent(player, new Attribute
            {
                hp = 100,
                maxHp = 100,
                attack = 5
            });
            entityManager.AddComponent(player, new Asset{
                AssetName = "Hero"
            });
            var heroAction = new Action();
            heroAction.ActionDataList.Add(new AttackActionData
            {
                Attack = AttackActionEnum.Attack,
                Frame = 20,
                EventFrame = 2
            });
            entityManager.AddComponent(player, heroAction);
            entityManager.AddComponent(player, new ReleaseSkillControl
            {
                SkillList = new []
                {
                    new ReleaseSkillData
                    {
                        Skill = SkillManager.CreateShootSkill(entityManager)
                    }
                }
            });

            return player;
        }
        
        public static int CreateMonster(EntityManager entityManager)
        {
            var monster = entityManager.CreateEntity();
            entityManager.AddComponent(monster, new Transform());
            entityManager.AddComponent(monster, new Ball
            {
                Radius = 5,
                Offset = new Vector3(0, 4.5f, 0)
            });
            entityManager.AddComponent(monster, new Character());
            entityManager.AddComponent(monster, new Hero());
            entityManager.AddComponent(monster, new AnimatorControl());
            entityManager.AddComponent(monster, new MonsterControl());
            entityManager.AddComponent(monster, new Attribute
            {
                hp = 100,
                maxHp = 100,
                attack = 10
            });
            entityManager.AddComponent(monster, new Asset{
                AssetName = "Monster"
            });
            var monsterAction = new Action();
            monsterAction.ActionDataList.Add(new AttackActionData
            {
                Attack = AttackActionEnum.Attack,
                Frame = 60,
                EventFrame = 37
            });
            entityManager.AddComponent(monster, monsterAction);
            entityManager.AddComponent(monster, new ReleaseSkillControl
            {
                SkillList = new []
                {
                    new ReleaseSkillData
                    {
                        Skill = SkillManager.CreateSkill(entityManager)
                    }
                }
            });

            return monster;
        }
    }
}