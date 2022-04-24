using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs1
{
    class Person
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public Person(string name)
        {
            this.Name = name;    
        }
    }
}
