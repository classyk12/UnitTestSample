using System.Linq;

namespace Unit_test_sample.Fundamentals
{
    public class RomanNumeralParser 
    {
        private string[] Notations = {"I", "V", "X", "L", "C","D", "M"};
        public int Parse (string symbol)
        {
            int value = 0;
            switch (symbol)
            {
                case "I":
               return value = 1;

                case "V":
                return value = 5;

                case "X":
               return value = 10;

                case "L":
               return value = 50;

                case "C":
               return value = 100;

                case "D":
               return value = 500;

                case "M":
               return value = 5000;

                default:
              return value;
            }


        }
    
    }
}