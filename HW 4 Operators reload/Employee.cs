using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Operators_reload
{
    public class Employee
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        private decimal salary;

        public decimal Salary 
        { 
            get { return salary; }
            set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("Зарплата должна быть в пределах от 0 до 100 000.");
                }
                else
                {
                    salary = value;
                }
            }
        }

        public Employee(string name, string surname, decimal salary)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee otherEmployee)
            {
                return this.Salary == otherEmployee.Salary;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Salary.GetHashCode();
        }

        public static Employee operator +(Employee emp, decimal addingToSalary)
        {
            emp.Salary += addingToSalary;

            return emp;
        }

        public static Employee operator -(Employee emp, decimal addingToSalary)
        {
            emp.Salary -= addingToSalary;

            return emp;
        }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary==emp2.Salary;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1.Salary == emp2.Salary);
        }


        public static bool operator >(Employee emp1, Employee emp2)
        {
            return (emp1.Salary > emp2.Salary);
        }

        public static bool operator <(Employee emp1, Employee emp2)
        {
            return (emp1.Salary < emp2.Salary);
        }

        public override string ToString()
        {
            return $"Имя: {this.Name} Фамилия: {this.Surname} Ставка:{this.Salary}";
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine(this);
        }
    }
}
