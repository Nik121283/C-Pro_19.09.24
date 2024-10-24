using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        bool Create(Patient patient);

        IEnumerable<Patient> GetAll();

        Patient? Get(int id);

        bool Delete(int id);

        bool Update(int id, Patient doctor);
    }
}
