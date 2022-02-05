using System;
using System.Collections.Generic;

namespace Patterns
{
    //enum EnemyTypes
    //{
    //    Skeleton,
    //    Zombi,
    //    Witch
    //}
    class EnemyGenerator
    {
        public List<Enemy> GetEnemies(int enemyAmount)
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            EnemyFactory[] enemyFactory = { new SkeletonFactory(),new ZombiFactory(), new WitchFactory() };
            for (int i = 0; i < enemyAmount; i++)
            {
                enemies.Add(enemyFactory[random.Next(3)].Create());
            }
            return enemies;
        }
    }

    abstract class Enemy
    {
        public int Damage { get; set; }
        public int HitPoints { get; set; }
        public string BattleRoar { get; set; }
    }

    interface IHorrorSounds
    {
        public void MakeHorrorNoise();
    }

    class Skeleton:Enemy, IHorrorSounds
    {
        public Skeleton()
        {
            Damage = 15;
            HitPoints = 100;
            BattleRoar = "Костяной грохот!";
        }
        public void MakeHorrorNoise()
        {
            Console.WriteLine($"{this.BattleRoar}");
        }
    }
    class Zombi:Enemy, IHorrorSounds
    {
        public Zombi()
        {
            Damage = 10;
            HitPoints = 200;
            BattleRoar = "Живая плоть!";
        }
        public void MakeHorrorNoise()
        {
            Console.WriteLine($"{this.BattleRoar}");
        }
    }
    class Witch:Enemy,IHorrorSounds
    {
        public Witch()
        {
            Damage = 35;
            HitPoints = 70;
            BattleRoar = "Иди прочь малолетка!";
        }
        public void MakeHorrorNoise()
        {
            Console.WriteLine($"{this.BattleRoar}");
        }
    }

    abstract class EnemyFactory
    {
        public abstract Enemy Create();
    }

    class SkeletonFactory:EnemyFactory
    {
        public override Enemy Create()
        {
            return new Skeleton();
        }
    }
    class ZombiFactory : EnemyFactory
    {
        public override Enemy Create()
        {
            return new Zombi();
        }
    }
    class WitchFactory : EnemyFactory
    {
        public override Enemy Create()
        {
            return new Witch();
        }
    }
}