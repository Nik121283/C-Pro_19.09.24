using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService : IServiceInterface<Appointment>
    {
         bool Create(Doctor doctor, Patient patient);
    }
}
