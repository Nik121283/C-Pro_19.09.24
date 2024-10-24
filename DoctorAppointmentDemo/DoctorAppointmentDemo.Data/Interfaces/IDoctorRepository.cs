using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        bool IncreaseSalary(int id, decimal addToSalary);

        bool DecreaseSalary(int id, decimal changesToSalary);

        IEnumerable<Doctor> GetAllbyDoctorTypes(DoctorTypes doctorTypes);

    }
}
