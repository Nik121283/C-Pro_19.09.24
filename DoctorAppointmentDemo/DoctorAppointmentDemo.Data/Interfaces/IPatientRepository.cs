using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        bool ChangeIllnessType(int id, IllnessTypes newIllnessType);

        bool ChangeAddress(int id, string newAddress);

        List<Patient> GetAllbyIllnessTypes(IllnessTypes illnessTypes);
    }
}
