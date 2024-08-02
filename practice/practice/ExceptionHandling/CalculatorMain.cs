using practice.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.ExceptionHandling;
using static System.Console;


namespace practice.ExceptionHandling
{
    public class CalculatorMain
    {
        public CalculatorMain() {

            WriteLine("Enter first number");
            int number1 = int.Parse(ReadLine());

            WriteLine("Enter second number");
            int number2 = int.Parse(ReadLine());

            WriteLine("Enter operation");
            string operation = ReadLine().ToUpperInvariant();


            var calculator = new Calculator();
            int result = calculator.Calculate(number1, number2, operation);
            DisplayResult(result);


            WriteLine("\nPress enter to exit.");
            ReadLine();
        }
        static void DisplayResult(int result) => WriteLine($"Result is: {result}");
    }
}
