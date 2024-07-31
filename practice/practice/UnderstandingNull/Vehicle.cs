using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.UnderstandingNull
{
    internal class Vehicle
    {
        int Tyres;
        public void DisplayTyres()
        {
            Tyres = 4;
            Console.WriteLine("The number of Tyres are" + Tyres);
        }
    }
}
