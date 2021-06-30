using System.Collections;
using NUnit.Framework;
using Unit_test_sample.Models;

namespace Unit_test_sample.UnitTest
{
    public class CharacterTestWithSetupAndTearDown
    {
       private Character _character;
        //setup and teardown mechanism is used to run some abirtiary code before the main code. more like a init(setup) and dispose (teardown).

        [SetUp]
        public void Setup() //run this method after every testable unit method block
        {
          _character = new Character(CharacterType.Elf, "Isah");
        }

        [TearDown]
        public void TearDown()
        {
            _character = null;
        }

        [Test]
         public void CheckIfCharacterDead()
        {
           //  Character c = new Character(CharacterType.Elf, "Isah");
             _character.Health = 0;
            Assert.That(_character.IsDead, Is.True);
        }

        [Test]
        public void CheckEmptyName()
        {
           // Character c = new Character(CharacterType.Elf, "");
            Assert.That(_character.Name, Is.Not.Empty);
        }

        #region PARAMETRIZED TEST
        // [TestCase(130)]
         [TestCase(120)]
         [TestCase(100)]
        public void HeathDamage_ReturnsCorrectValue(int expectedHealth)
        {
            //  Assert.That(_character.Health, Is.LessThanOrEqualTo(expectedHealth));
            //  Assert.That(_character.Health, Is.Positive);

              Assert.That(_character.Health, Is.LessThanOrEqualTo(expectedHealth));
              Assert.That(_character.Health, Is.Positive);
        }
        #endregion

        #region Using Data Source
    
        [TestCaseSource(typeof(ExpectedHealthValues))]    
        public void HeathDamage_ReturnsCorrectValueWithDataSource (int expectedHealth)
        {
              Assert.That(_character.Health, Is.LessThanOrEqualTo(expectedHealth));
              Assert.That(_character.Health, Is.Positive);
        }
        #endregion

        public class ExpectedHealthValues : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new int[] {120};
                yield return new int[] {100};
            }
        }


        //NON PARAMERIZED TEST
        //    [Test]
        //     public void DefaultHealthIs100()
        //     {
        //        // Character c = new Character(CharacterType.Elf, "Gogo");
        //         const double expectedHealth = 130;
        //         Assert.That(_character.Health, Is.LessThanOrEqualTo(expectedHealth));
        //         Assert.That(_character.Health, Is.Positive);
        //     }

        //     [Test]
        //     public void DefaultHealthIs120()
        //     {
        //        // Character c = new Character(CharacterType.Elf, "Gogo");
        //         const double expectedHealth = 120;
        //         Assert.That(_character.Health, Is.LessThanOrEqualTo(expectedHealth));
        //         Assert.That(_character.Health, Is.Positive);
        //     }
    }
}