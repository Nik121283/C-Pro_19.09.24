using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BarberShop
{
    public class Customer
    {
        public string CustomersName { get; }

        public bool IsGettingHaircut { get; set; }

        public Customer(string name)
        {
            CustomersName = name;
            IsGettingHaircut = false;
        }
    }
}
