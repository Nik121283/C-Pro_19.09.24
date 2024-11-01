using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        public bool IncreaseSalary(int id, decimal addToSalary);

        public bool DecreaseSalary(int id, decimal changesToSalary);

        public List<Doctor> GetAllbyDoctorTypes(DoctorTypes doctorTypes);

    }
}
