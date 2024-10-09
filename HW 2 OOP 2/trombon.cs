using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    public class Trombon : Musical_instrument
    {

        public Trombon(string name, string desc, string history) : base(name, desc, history) { }

        public override void MakeSound()
        {
            Console.WriteLine("Trombon Sound");
        }
    }
}
