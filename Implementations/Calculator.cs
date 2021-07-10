using System;
using Unit_test_sample.Interfaces;

namespace Unit_test_sample.Implementations
{
    public class Calculator : ICalculator
    {
        private IExchangeRateProvider _provider;
        public Calculator(IExchangeRateProvider provider)
        {
            _provider = provider;
        }

        #region ICalculator Members
        public int Add(int param1, int param2)
        {
            return param1 + param2;
        } 
        public int Subtract(int param1, int param2)
        {
            if(param2 > param1)
            throw new InvalidOperationException();

            return param1 - param2;
        }
        public int Multipy(int param1, int param2)
        {
           return param1 * param2;
        }
        public int Divide(int param1, int param2)
        {
           if(param2 == 0)
           throw new DivideByZeroException();

           return param1 / param2;
        }
        public int ConvertUSDtoCLP(int unit)
        {
            return unit * this._provider.GetActualUSDValue();
        }
        #endregion
    }
}
