using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_Garbage_collector
{
    public class Play : IDisposable
    {
        public string? PlayName { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public int Year { get; set; }

        public Play(string playName, string author, string genre, int year)
        {
            PlayName = playName;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return $"Название:{this.PlayName} Автор:{this.Author} Жанр:{this.Genre} Год:{this.Year}";
        }

        public void Show()
        {
            Console.WriteLine(this);
        }

        public void Dispose()
        {
            Console.WriteLine("\nСработал Dispose метод класса Play.");
        }

        ~Play() 
        {
            Console.WriteLine("\nСработал деструктор класса Play.");
        }
    }
}
