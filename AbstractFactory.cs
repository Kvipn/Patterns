using System;
using System.Collections.Generic;

namespace Patterns
{
    class UnitGenerator
    {
        public List<Unit> GetUnits(int unitAmount)
        {
            List<Unit> units = new List<Unit>();
            Random random = new Random();
            UnitFactory[] unitFactory = { new ArcherFactory(), new InfantryFactory(), new KnightFactory() };
            for (int i = 0; i < unitAmount; i++)
            {
                units.Add(new Unit(unitFactory[random.Next(3)]));
            }
            return units;
        
        }
    }

    class Unit
    {
        Weapon firstWeapon;
        Weapon secondWeapon;
        Armor armor;
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public string BattleRoar { get; set; }

        public Unit(UnitFactory factory)
        {
            firstWeapon = factory.CreateFirstWeapon();
            secondWeapon = factory.CreateSecondWeapon();
            armor = factory.CreateArmor();
            Damage = 10 + firstWeapon.Damage + secondWeapon.Damage;
            HitPoints = 50 + armor.HitPoints;
            switch (armor)
            {
                case LightArmor:BattleRoar = "Моя меткость паразит вас!"; break;
                case MediumArmor:BattleRoar = "Пехтура никого не пропустит!"; break;
                case HeavyArmor:BattleRoar = "Почуствуй кровь мой меч!"; break;
                default:
                    break;
            }
        }
    }

    //class Archer : Unit
    //{

    //}
    //class Infantry : Unit
    //{

    //}
    //class Knight : Unit
    //{

    //}

    abstract class Weapon
    {
        public int Damage { get; set; }
        public string WeaponType { get; set; }
    }

    class Bow : Weapon
    {
        public Bow()
        {
            Damage = 20;
            WeaponType = "Bow";
        }
    }
    class Pike : Weapon
    {
        public Pike()
        {
            Damage = 30;
            WeaponType = "Pike";
        }
    }
    class Axe : Weapon
    {
        public Axe()
        {
            Damage = 15;
            WeaponType = "Axe";
        }
    }
    class Swodr : Weapon
    {
        public Swodr()
        {
            Damage = 50;
            WeaponType = "Sword";
        }
    }

    abstract class Armor
    {
        public int HitPoints { get; set; }
        public string ArmorType { get; set; }
    }

    class LightArmor : Armor
    {
        public LightArmor()
        {
            HitPoints = 20;
            ArmorType = "Light Armor";
        }
    }
    class MediumArmor : Armor
    {
        public MediumArmor()
        {
            HitPoints = 40;
            ArmorType = "Medium Armor";
        }
    }
    class HeavyArmor : Armor
    {
        public HeavyArmor()
        {
            HitPoints = 60;
            ArmorType = "Heavy Armor";
        }
    }

    abstract class UnitFactory
    {
        public abstract Weapon CreateFirstWeapon();
        public abstract Weapon CreateSecondWeapon();
        public abstract Armor CreateArmor();
    }

    class ArcherFactory:UnitFactory
    {
        public override Weapon CreateSecondWeapon()
        {
            return new Axe();
        }
        public override Weapon CreateFirstWeapon()
        {
            return new Bow();
        }
        public override Armor CreateArmor()
        {
            return new LightArmor();
        }
    }
    class InfantryFactory : UnitFactory
    {
        public override Weapon CreateSecondWeapon()
        {
            return new Axe();
        }
        public override Weapon CreateFirstWeapon()
        {
            return new Pike();
        }
        public override Armor CreateArmor()
        {
            return new MediumArmor();
        }
    }
    class KnightFactory  : UnitFactory
    {
        public override Weapon CreateSecondWeapon()
        {
            return new Swodr();
        }
        public override Weapon CreateFirstWeapon()
        {
            return new Pike();
        }
        public override Armor CreateArmor()
        {
            return new LightArmor();
        }
    }
}