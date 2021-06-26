using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest
{

    //mStEST: [TestClass]
    [TestFixture]
    public class SerialPortParserTest //name of the class we are testing for
    {
        [Test]
        public void ParsePort_IsValidPortNumber_Returns45()
        {
            //arrange             
            
            //act
            var result =  SerialPortParser.ParsePort("COM45");
          
            //assert
            Assert.That(result == 45);
        }
    }
}
