using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json.Serialization;
using MyDoctorAppointment.Data.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override ISerializationService SerializationService { get; set; }

        public override string Path { get; set; }

        public override int LastId { get; set; }

        //конструктор
        public PatientRepository(string appSetings, ISerializationService serializationService) : base (appSetings, serializationService)
        {
            this.SerializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            var result = GetAll();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            SerializationService.Serialize(AppSetings, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }

        public bool ChangeIllnessType(int id, IllnessTypes newIllnessType)
        {
            var patient = base.GetById(id);

            if (patient != null)
            {
                patient.IllnessType = newIllnessType;

                base.Update(id, patient);

                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool ChangeAddress(int id, string newAddress)
        {
            var patient = base.GetById(id);

            if (patient != null)
            {
                patient.Address = newAddress;

                base.Update(id, patient);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Patient> GetAllbyIllnessTypes(IllnessTypes illnessTypes)
        {
            return GetAll().Where(x => x.IllnessType == illnessTypes).ToList();
        }
    }
}
