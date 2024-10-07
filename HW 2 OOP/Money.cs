using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_OOP
{
    public class Money
    {
        public int dollars;

        public int cents;

        public Money(float sartingCash)
        {
            dollars = (int)(sartingCash / 1);
            cents = (int)((sartingCash - dollars)*100);
        }

        public void ShowAccountStatement()
        {
            Console.WriteLine($"{dollars},{cents}");
        }
    }
}
