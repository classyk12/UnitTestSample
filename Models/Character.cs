using System;
using System.Collections.Generic;

namespace Unit_test_sample.Models
{
    public class Character
    {
        public CharacterType Type { get; set; }
         public string Name { get; set; }
        public ICollection<string> Weaponry { get; set; }
        public Character(CharacterType type, string name)
        {
            Type = type;
            Name = name;
            Weaponry = new List<string>();
        }
       
        public ICollection<string> SuperPowers { get; set; }
       
         public double Damage { get; set; } = 120;

         public double MaximumSpeed => Type == CharacterType.Human ? 1.5 : 2.0;
        public double Health { get; set; } = 100;
        public bool IsDead => Health <= 0;


        public double MaxDamage(double value)
        {
            if(value > 100)
            throw new ArgumentOutOfRangeException();

            if(value == 0)
            throw new ArgumentNullException();

            return value;
        }
    }

    public enum CharacterType
    {
        Beast = 1,
        Elf,
        Human
    }
}


