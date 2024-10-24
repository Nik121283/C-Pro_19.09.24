using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        bool Create(Doctor doctor);

        IEnumerable<Doctor> GetAll();

        Doctor? Get(int id);

        bool Delete(int id);

        bool Update(int id, Doctor doctor);
    }
}
