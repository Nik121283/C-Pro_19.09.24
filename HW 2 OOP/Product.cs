using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_OOP
{
    public class Product
    {
        private static int numerator = 0;
        private int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Money { get; set; }

        public Product(string name, string description, float price)
        {
            this.Id = numerator;
            numerator++;

            this.Name = name;
            this.Description = description;
            this.Money = new Money(price);

        }

        public Product(string name, string description, int priceDollars, int priceCents)
        {
            this.Id = numerator;
            numerator++;

            this.Name = name;
            this.Description = description;
            this.Money = new Money(priceDollars, priceCents);
        }


        public void MakeHigherPrice(float addToPrice)
        {
            Money.ChangeMoney(addToPrice);
        }

        public void MakeLowerPrice(float addToPrice)
        {
            Money.ChangeMoney(- addToPrice);
        }

        public void ShowProductInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString() { return $"Id:{this.Id} Name:{this.Name} Descr:{this.Description} Price:{this.Money.ReturnAccountStatement()}"; }
    }
}
