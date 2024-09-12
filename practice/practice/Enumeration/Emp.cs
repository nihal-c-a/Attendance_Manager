using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Enumeration
{
    public  enum DayOfWeek
    {
        Sunday,    // 0
        Monday,    // 1
        Tuesday,   // 2
        Wednesday, // 3
        Thursday,  // 4
        Friday,    // 5
        Saturday   // 6
    }
    public class Emp
    {
        

        public  void EnumExample()
        {
            // Declare a variable of type 'DayOfWeek' and assign a value
            DayOfWeek today = DayOfWeek.Wednesday;

            // Output the value of 'today'
            Console.WriteLine("Today is: " + today);

            // Output the underlying integer value of 'today'
            Console.WriteLine("Integer value of today is: " + (int)today);

            // Using a switch statement with the enum
            switch (today)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Start of the work week.");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Middle of the work week.");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("End of the work week.");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Weekend!");
                    break;
                default:
                    Console.WriteLine("Not a work day.");
                    break;
            }
        }
    }
}
