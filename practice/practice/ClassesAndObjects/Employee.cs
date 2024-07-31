using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.ClassesAndObjects
{

    public class Employee
    {
        // Properties
        public string firstName;
        public int Age;

        // Constructor
        public Employee(string name, int ageValue)
        {
            firstName = name;
            Age = ageValue;
        }
        public void ChangeName(ref string Name)
        {
            Name = "nihal Basheer";
        }
        public void OutExample(string name, out string outVariable)
        {
            outVariable = "Initialized";

        }

    }   

 }
