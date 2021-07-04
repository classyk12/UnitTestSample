
using System.Collections;
using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest.BusinessTest
{
    [TestFixture]
    public class FizzBuzzTest
    {

        #region 
        // [TestCase(15)]
        // [TestCase(60)]
        // [TestCase(90)]
        [TestCaseSource(typeof(NumberDivisibleBy3And5DataSource))]
        public void Ask_NumberDivisibleBy3And5_ReturnsFizzBuzz(int askingNumber)
        {
            var result = FizzBuzz.Ask(askingNumber);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [TestCase(9)]
        [TestCase(18)]
        [TestCase(50)]
        public void Ask_NumberDivisibleBy3_ReturnsFizz(int askingNumber)
        {
            var result = FizzBuzz.Ask(askingNumber);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [TestCase(5)]
        [TestCase(25)]
        [TestCase(35)]
        public void Ask_NumberDivisibleBy5_ReturnsFizz(int askingNumber)
        {
            var result = FizzBuzz.Ask(20);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        // [TestCase(1)]
        // [TestCase(7)]
        // [TestCase(11)]
        [TestCaseSource(typeof(NumberNotDivisibleByBy3And5))]
        public void Ask_NumberNotDivisibleByBy3And5_ReturnsEmptyString(int askingNumber)
        {
            var result = FizzBuzz.Ask(askingNumber);
            Assert.That(result, Is.Empty);
        }

        public class NumberDivisibleBy3And5DataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
               yield return new int[] {15};
               yield return new int[] {60};
               yield return new int[] {90};
            }
        }

        public class NumberNotDivisibleByBy3And5 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
               yield return new int[] {1};
               yield return new int[] {7};
               yield return new int[] {11};
            }
        }
   
        #endregion
   
    }

        #region 
        [TestFixture]
        public class FizzBuzzTestRefactored
        {
          [TestCase("FizzBuzz",15)]
          [TestCase("FizzBuzz",60)]
          [TestCase("Fizz", 9)]
          [TestCase("Fizz", 18)]
          [TestCase("Buzz", 35)]
          [TestCase("Buzz", 25)]
          [TestCase("", 7)]
        public void TestFizzBuzz (string expected, int askingNumber)
        {
            var result = FizzBuzz.Ask(askingNumber);
            Assert.That(result, Is.EqualTo(expected));
        }
        }
        #endregion

}