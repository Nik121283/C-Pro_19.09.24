using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService : IServiceInterface<Doctor>
    {
        public Doctor DoctorsEnterFromConsole();

        public bool IncreaseSalaryById(int id, decimal addToSalary);

        public bool DecreaseSalaryById(int id, decimal addToSalary);
    }
}
