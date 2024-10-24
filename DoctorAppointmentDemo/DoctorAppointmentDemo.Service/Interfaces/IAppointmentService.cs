using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        bool Create(Appointment patient);

        IEnumerable<Appointment> GetAll();

        Appointment? Get(int id);

        bool Delete(int id);

        bool Update(int id, Appointment doctor);
    }
}
