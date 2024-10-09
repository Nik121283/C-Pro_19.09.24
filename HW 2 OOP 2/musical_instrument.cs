using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    public class Musical_instrument
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string History { get; set; }


        public Musical_instrument(string name, string desc, string history)
        {
            Name = name;
            Description = desc;
            History = history;
        }

        public virtual void MakeSound()
        {
            
        }

        public void ShowName()
        {
            Console.WriteLine(Name);
        }
        public void ShowDescription()
        {
            Console.WriteLine(Description);
        }

        public void ShowHistory()
        {
            Console.WriteLine(History);
        }
    }
}
