using System;
using NUnit.Framework;
using Unit_test_sample.Fundamentals;
using Unit_test_sample.Models;

namespace Unit_test_sample.UnitTest
{

    [TestFixture]
    public class CharacterTest 
    {
        #region StringTest
        [Test]
        public void ShouldSetName()
        {
            string expected = "Mason";
            Character _character = new Character(CharacterType.Beast, expected);
            Assert.That(_character.Name, !Is.Empty); //check if name is empty
            Assert.That(_character.Name, Is.EqualTo(expected));  //check if expected name is equal to the name passed to the constructor
            Assert.That(_character.Name, !Contains.Substring("Ohn").IgnoreCase); //check if name contains a substring       
        }

          [Test]
        public void ShouldSetNameCaseInsensitive()
        {
            string expectedUpperCase = "MASON";
            string expectedLowerCase = "mason";
            Character c =  new Character(CharacterType.Beast, expectedUpperCase);

            Assert.That(c.Name, Is.EqualTo(expectedLowerCase).IgnoreCase); //check if the names are equal     
        }
        
        #endregion

        #region NumericalTest
        [Test]
        public void DefaultHealthIs100()
        {
            Character c = new Character(CharacterType.Elf, "Gogo");
            const double expectedHealth = 120;
            Assert.That(c.Health, Is.LessThanOrEqualTo(expectedHealth));
            Assert.That(c.Health, Is.Positive);
        }
        #endregion
    
        #region 
        [Test]
        public void Beast_IsSpeedCorrect()
        {
            Character c = new Character(CharacterType.Beast, "Gogo");
            const double expctedSpeed = 2.0;
            Assert.That(c.MaximumSpeed, Is.EqualTo(expctedSpeed));
        }

        [Test]
         public void Other_IsSpeedCorrect()
        {
             Character c = new Character(CharacterType.Human, "Isah");
            const double expctedSpeed = 1.7;
            Assert.That(c.MaximumSpeed, Is.LessThanOrEqualTo(expctedSpeed));
        }

        [Test]
         public void Beast_SpeedIsCorrectWithTolerance()
        {
            Character c = new Character(CharacterType.Elf, "Masha");
            const double expctedSpeed = 0.3 + 1.1;
            Assert.That(c.MaximumSpeed, Is.EqualTo(expctedSpeed).Within(0.5));
              Assert.That(c.MaximumSpeed, Is.EqualTo(expctedSpeed).Within(1).Percent);
        }

         [Test]
         public void SideCheck_CheckDateRange()
        {
            var dt =  new DateTime(2001,1,1);
           Assert.That(dt, Is.EqualTo(new DateTime(2002,1,1)).Within(TimeSpan.FromDays(366)));
         Assert.That(dt, Is.EqualTo(new DateTime(2002,1,1)).Within(366).Days);
        }
        #endregion
       
         #region 
        [Test]
        public void CheckEmptyName()
        {
            Character c = new Character(CharacterType.Beast, "");
            Assert.That(c.Name, Is.Empty);
        }

        [Test]
         public void CheckIfCharacterDead()
        {
             Character c = new Character(CharacterType.Elf, "Isah");
            c.Health = 0;
            Assert.That(c.IsDead, Is.True);
        }
        #endregion

         #region Collections
        [Test]
        public void CollectionTest()
        {
            Character c = new Character(CharacterType.Beast, "Gogo");
            
             c.Weaponry.Add("axe");         
             c.Weaponry.Add("cane");
             c.Weaponry.Add("shovel");

           

             //check if the weaponry is empty
             Assert.That(c.Weaponry, !Is.All.Empty);
             //check if the weapoonry is ordered
             Assert.That(c.Weaponry, Is.Ordered);
             //check if the items in the weaponry are unique
              Assert.That(c.Weaponry, Is.Unique);
             //check if the items are exaclty 3
             Assert.That(c.Weaponry, Has.Exactly(3).Length);
             //check if the items is 1 in lenght and contains a substring 
             Assert.That(c.Weaponry, Has.Exactly(1).Items.EndsWith("ane"));

             Character c2 =  new Character(CharacterType.Human, "Masha");
             c2.Weaponry.Add("axe");         
             c2.Weaponry.Add("Cane");
             c2.Weaponry.Add("Shovel");

             Assert.That(c.Weaponry, Is.EquivalentTo(c2.Weaponry).IgnoreCase);

          
        }
        #endregion
    
        #region Reference Equality
        [Test]
        public void SameCharacter_EqualByReference()
        {
            Character c = new Character(CharacterType.Beast, "Gogo");
            var c2 = c;
           // var c2 = new Character(CharacterType.Beast, "Gogo");
            Assert.That(c, Is.SameAs(c2)); //reference or compares and returns true if they re the same object 
        }
        #endregion
    
        #region Types
        [Test]
        public void SameObject_EqualByType()
        {
            var c = new Character(CharacterType.Beast, "Gogo");    
            Assert.That(c, Is.Not.TypeOf<User>()); //checks object type
        }
        #endregion

         #region Ranges
        [Test]
        public void DefaultCharacterDamageShouldBeLessThan100AndGreaterThan30()
        {
            var c = new Character(CharacterType.Beast, "Gogo");    
            Assert.That(c.Damage, Is.GreaterThanOrEqualTo(100).And.GreaterThan(30));
        }
        #endregion

         #region Exceptions
        [Test]
        public void Damage_1000_ThrowsOutOfRangeException()
        {
            var c = new Character(CharacterType.Beast, "Gogo");    
            c.Damage = 2000;
            Assert.Throws<ArgumentOutOfRangeException>(() => c.MaxDamage(c.Damage));
        }

          [Test]
        public void NullCharacterObject_Throws_ArgumentNullException()
        {
            var c = new Character(CharacterType.Beast, "Gogo");    
           
            Assert.Throws<ArgumentNullException>(() => c.MaxDamage(0));
        }
        #endregion

    }
}
