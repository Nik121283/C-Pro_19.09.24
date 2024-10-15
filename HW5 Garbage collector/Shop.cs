using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_Garbage_collector
{
    public class Shop : IDisposable
    {
        public string? ShopsName { get; set; }

        public string? Address { get; set; }

        public string? ShopsType { get; set;}

        private bool disposed = false;

        public Shop(string name, string address, string type)
        {
            ShopsName = name;
            Address = address;
            ShopsType = type;
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Имя:{this.ShopsName} Адрес:{this.Address} Тип магазина:{this.ShopsType}";
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Console.WriteLine("Вызван метод Dispose на экз класса Shop");
                return;
            }
            Console.WriteLine("Вызван метод Деструктор на экз класса Shop");
            disposed = true;
        }

        ~Shop() 
        {
            Console.WriteLine("Вызван метод Деструктор на экз класса Shop");
        }
    }
}
