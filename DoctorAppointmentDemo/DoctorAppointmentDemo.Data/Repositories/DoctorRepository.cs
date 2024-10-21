using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json.Serialization;
using MyDoctorAppointment.Data.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ISerializationService serializationService;

        public override string Path { get; set; }

        public override int LastId { get; set; }

        //конструктор
        public DoctorRepository(string appSetings, ISerializationService serializationService)
        {
            this.serializationService = serializationService;

            dynamic result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine(); // implement view of all object fields
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            serializationService.Serialize<Doctor>(Path, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }
    }
}
