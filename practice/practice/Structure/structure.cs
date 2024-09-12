using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Structure
{
    internal struct structure
    {
        public string description;
        public void InitializeDescription(string desc)
        {
            description = desc;
            Console.WriteLine(desc);
        }
    }
}
