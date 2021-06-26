using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest
{

    //mStEST: [TestClass]
    [TestFixture]
    public class DegreeConverterTest 
    {
        [Test]
        public void DegreeConverter_ConvertToFahrenheit_Returns0()
        {
           //arrange
           DegreeConverter converter = new DegreeConverter();

           //act
           double result = converter.ToCelsuis(1);

           //assert
           Assert.That(result, Is.EqualTo(0));
        }

        [Test]

         public void DegreeConverter_ConvertToCelsuis_Returns32()
        {
           //arrange
           DegreeConverter converter = new DegreeConverter();

           //act
           double result = converter.ToFarhenheit(0);

           //assert
           Assert.That(result == 32);
        }
    }
}
