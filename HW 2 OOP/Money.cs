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

        public float cents;

        public Money(float sartingCash)
        {
            if(sartingCash < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            dollars = (int)(sartingCash / 1);
            cents = (int)Math.Round((sartingCash - dollars)*100);
        }
        public Money(int sartingCashDollars, int sartingCashCents)
        {
            if (sartingCashDollars < 0 || sartingCashCents<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            dollars = sartingCashDollars;
            cents = sartingCashCents;
        }

        public void ChangeMoney(float changingSum)
        {
            this.dollars = dollars + (int)(changingSum / 1);
            this.cents = cents + (int)Math.Round(((int)(changingSum / 1) - changingSum) * 100);
        }

        public string ReturnAccountStatement()
        {
            return $"{dollars},{cents}";
        }

        public void ShowAccountStatement()
        {
            Console.WriteLine($"{dollars},{cents}");
        }
    }
}
