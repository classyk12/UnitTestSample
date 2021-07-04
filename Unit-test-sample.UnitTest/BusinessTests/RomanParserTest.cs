using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest.BusinessTest
{
    #region 
    [TestFixture]
        public class RomanNumeralParserTest
        {
          [TestCase("I",1)]
          [TestCase("V",5)]
          [TestCase("X", 10)]
          [TestCase("L", 50)]
          [TestCase("C", 100)]
          [TestCase("D", 500)]
          [TestCase("M", 5000)]
          [TestCase("A", 0)]
        public void RomanNumeralParser_VerifiesInput_ReturnsInt (string inputValue, int expected)
        {
            RomanNumeralParser r = new RomanNumeralParser();
            var result = r.Parse(inputValue);
            Assert.That(result, Is.EqualTo(expected));
        }

        }
        #endregion

}