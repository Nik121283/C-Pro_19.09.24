using MyDoctorAppointment.Domain.Enums;
using System.Net;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment : Auditable
    {
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }

        public override string ToString()
        {
            return $"Врач:{Doctor.Name} {Doctor.Surname}  Пациент {Patient.Name} {Patient.Surname} Дата визита:{DateTimeFrom.Date}";
        }
    }
}
