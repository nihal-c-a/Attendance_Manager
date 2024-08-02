using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.ExceptionHandling
{
    public class Calculator
    {
        public int Calculate(int number1, int number2, string operation)
        {
            if (operation == "/")
            {
                return Divide(number1, number2);
            }
            else
            {
                Console.WriteLine("Unknown operation.");
                return 0;
            }
        }

        private int Divide(int number, int divisor) => number / divisor;
    }

}
