using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    internal class overloading
    {
        public void Disp(int a , int b=10)
        {
            Console.WriteLine(a + " " + b);
        }
        public void Disp(int b)
        {
            Console.WriteLine(b);
        }
        public int SingleLine() => 40;

    }
}
