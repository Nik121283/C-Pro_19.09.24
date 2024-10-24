using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }


        public override string ToString()
        {
            return $"{base.Name} {base.Surname} Профиль доктора:{DoctorType} Опыт работы:{Experience} Зарплата:{Salary}";
        }
    }
}
