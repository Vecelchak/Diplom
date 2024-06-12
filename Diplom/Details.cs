using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class Details
    {
        public string Name { get; private set; }
        public string Quantity { get; private set; }
        public string Mass { get; private set; }
        public string Format { get; private set; }
        public string Designation { get; private set; }
        public string Litera { get; private set; }
        public Details(string name, string quantity, string mass, string format, string designation, string litera)
        {
            Name = name;
            Quantity = quantity;
            Mass = mass;
            Format = format;
            Designation = designation;
            Litera = litera;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}