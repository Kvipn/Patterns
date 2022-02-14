using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Enemy> enemies = new List<Enemy>();
            EnemyGenerator generator = new EnemyGenerator();
            enemies.AddRange(generator.GetEnemies(18));
            
            List<Unit> units = new List<Unit>();
            UnitGenerator unitGenerator = new UnitGenerator();
            units.AddRange(unitGenerator.GetRandomUnits(12));

            Console.WriteLine( Program.Fight(units,enemies));


        }

        static public string Fight(List<Unit> units , List<Enemy> enemies)
        {
            Random random = new Random();
            int EnemyDamage = enemies.Sum(n=>n.Damage);
            int EnemyHitpoints = enemies.Sum(n=>n.HitPoints);
            int UnitDamage = units.Sum(n=>n.Damage);
            int UnitHitpoints = units.Sum(n=>n.HitPoints);
            
            Console.WriteLine($"Суммарное здоровье людей {UnitHitpoints}.\r\n" +
                    $"Суммарное здоровье нелюдей {EnemyHitpoints}");

            for (int i = 0; ;i++)
            {
                Console.WriteLine($"Раунд {i+1}!");
                EnemyHitpoints -= UnitDamage;
                UnitHitpoints -= EnemyDamage;
                if (EnemyHitpoints<=0 && UnitHitpoints<=0)
                {
                    return "Ничья!!!";
                }
                else if(EnemyHitpoints <= 0)
                {
                    return "Победа людей!";
                }
                else if(UnitHitpoints <= 0)
                {
                    return "Мир людей падет!";
                }
                Console.WriteLine($"Суммарное здоровье людей {UnitHitpoints}.\r\n" +
                    $"Суммарное здоровье нелюдей {EnemyHitpoints}");
                Console.WriteLine(units[random.Next(units.Count)].BattleRoar);
                Console.WriteLine(enemies[random.Next(enemies.Count)].BattleRoar);
                        
            }

        }
    }
}
