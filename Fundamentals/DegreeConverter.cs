using System;

namespace Unit_test_sample.Fundamentals
{
    public class DegreeConverter
    {
        public double ToFarhenheit (double celsuis )
        {
           return (celsuis * 9 /5) + 32;
        }

        public double ToCelsuis (double fahrenheit )
        {
           return (32 * fahrenheit - 32) * 5 / 9;
        }
    }
}
