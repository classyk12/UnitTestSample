using System;
using Moq;
using NUnit.Framework;
using Unit_test_sample.Implementations;
using Unit_test_sample.Interfaces;

namespace Unit_test_sample.UnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        public IExchangeRateProvider GetExchangeMockProvider()
        {
            Mock<IExchangeRateProvider> _mockObject = new Mock<IExchangeRateProvider>();
            _mockObject.Setup(m => m.GetActualUSDValue()).Returns(500);
            return _mockObject.Object;
        }
        private IExchangeRateProvider _provider;
        private ICalculator _cal;

        [SetUp]
        public void SetUp()
        {
            _provider = GetExchangeMockProvider();
            _cal = new Calculator(_provider);
        }
        
        //setup mock object
        [TestCase(12,10, 22)]
        [TestCase(1,1, 2)]
        [TestCase(0,0, 0)]
        public void Calculator_AddNumbers_ReturnsValue(int valA,int valB, int expected)
        {
         //  ICalculator _cal =  new Calculator(_provider);
           var result = _cal.Add(valA, valB);
           Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(12,10, 2)]
        [TestCase(1,1, 0)]
        [TestCase(0,0, 0)]
        public void Calculator_SubtractNumbers_ReturnsValue(int valA,int valB, int expected)
        {
        //   ICalculator _cal =  new Calculator(GetExchangeMockProvider());
           var result = _cal.Subtract(valA, valB);
           Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2,10)]
        [TestCase(1,15)]
        [TestCase(0,12)]
        public void Calculator_SubtractNumbers_ReturnsException(int valA,int valB)
        {
          // ICalculator _cal =  new Calculator(GetExchangeMockProvider());
            Assert.Throws<InvalidOperationException>(() => _cal.Subtract(valA, valB));
        }

        [TestCase(2,10, 20)]
        [TestCase(1,15, 15)]
        [TestCase(0,12, 0)]
        public void Calculator_MultiplyNumbers_ReturnsValue(int valA,int valB, int expected)
        {
          // ICalculator _cal =  new Calculator(GetExchangeMockProvider());
           var result = _cal.Multipy(valA, valB);
           Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10,2, 5)]
        [TestCase(25,5, 5)]
        public void Calculator_DivideNumbers_ReturnsValue(int valA,int valB, int expected)
        {
           ICalculator _cal =  new Calculator(GetExchangeMockProvider());
           var result = _cal.Divide(valA, valB);
           Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(12,0)]
        [TestCase(17,0)]
        public void Calculator_DivideNumbers_ReturnsException(int valA,int valB)
        {
           ICalculator _cal =  new Calculator(GetExchangeMockProvider());
           Assert.Throws<DivideByZeroException>(() => _cal.Divide(valA, valB));
        }

        [TestCase(1, 500)]
        [TestCase(2, 1000)]
        [TestCase(3, 1500)]
        public void Calculator_DivideNumbers_ReturnsExchangeRate(int unit, int expected)
        {
           ICalculator _cal =  new Calculator(GetExchangeMockProvider());
           var result = _cal.ConvertUSDtoCLP(unit);
           Assert.That(result, Is.EqualTo(expected));
        }
    }
}
