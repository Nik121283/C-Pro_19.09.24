using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? Address { get; set; }

        public Patient(string name, string surname, string phone, string email, IllnessTypes illnessTypes, string additionalInfo, string address) : base ( name, surname, phone, email)
        {
            IllnessType = illnessTypes;

            AdditionalInfo = additionalInfo;

            Address = address;
        }


        public override string ToString()
        {
            return $"{base.Name} {base.Surname} Болезнь:{IllnessType} Адресс:{Address}";
        }
    }
}
