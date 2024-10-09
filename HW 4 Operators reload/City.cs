using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Operators_reload
{
    public class City
    {
        public string NameOfTheCity { get; set; }

        private int population;

        public int Population 
        { 
            get { return population; }
            set { if (value < 0 || value > 50000000) { throw new ArgumentOutOfRangeException(); } else { population = value; } }
        }

        public City( string nameOfTheCity, int population)
        {
            this.NameOfTheCity = nameOfTheCity;
            this.Population = population;
        }

        public override int GetHashCode()
        {
            return NameOfTheCity.GetHashCode();  
        }

        public override bool Equals(object? obj)
        {
            if(obj != null) 
            {
                if(obj is City city2)
                {
                    return this.population == city2.population;
                }
            }
            return false;
        }

        public static City operator +(City city1, int addingPopulation)
        {
            city1.population += addingPopulation;
            return city1;
        }

        public static City operator -(City city1, int subtractionPopulation)
        {
            city1.population -= subtractionPopulation;
            return city1;
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.population == city2.population;
        }

        public static bool operator !=(City city1, City city2)
        {
            return !(city1.population == city2.population);
        }


        public static bool operator >(City city1, City city2)
        {
            return (city1.population > city2.population);
        }

        public static bool operator <(City city1, City city2)
        {
            return (city1.population < city2.population);
        }
    }
}
