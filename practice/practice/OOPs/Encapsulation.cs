using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.OOPs
{
    public class Encapsulation
    {
        private int pin;
        public int Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }
        public virtual void DisplayPin()
        {
            Console.WriteLine(pin);
        }
    }
    public class EncapsulatedChild: Encapsulation
    {
        public void DisplayChild()
        {
            Console.WriteLine("this is the child class method");
        }
        public override void DisplayPin()
        {
            Console.WriteLine("Child class Pin display method");
        }

    }
}
