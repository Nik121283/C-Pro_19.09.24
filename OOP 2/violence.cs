﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Violence : Musical_instrument
    {
        public Violence(string name, string desc, string history) : base(name, desc, history) { }

        public override void MakeSound()
        {
            Console.WriteLine("Violence Sound");
        }
    }
}
