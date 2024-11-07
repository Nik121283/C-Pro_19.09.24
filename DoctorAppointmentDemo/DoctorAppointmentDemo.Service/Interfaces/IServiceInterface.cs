using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IServiceInterface<T>
    {
         bool Create();

        IEnumerable<T> GetAll();

        T? Get(int id);

        bool Delete(int id);

        bool Update(int id, T newEntity);

        int GetId()
        {
            int result;

            Console.WriteLine("Введите Id");
            if (!int.TryParse(Console.ReadLine(), out result) || result <0)
            {
                Console.WriteLine("Введено недопустимое значение");
            }

            return result;
        }



    }
}
