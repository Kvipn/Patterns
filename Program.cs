using System;
using System.Collections.Generic;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Enemy> enemies = new List<Enemy>();
            EnemyGenerator generator = new EnemyGenerator();
            enemies.AddRange(generator.GetEnemies(12));
            
            foreach (var item in enemies)
            {
                Console.WriteLine(item.BattleRoar);
            }
        }
    }
}
