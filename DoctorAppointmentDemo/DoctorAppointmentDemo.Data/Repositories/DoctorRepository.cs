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
        public override ISerializationService SerializationService { get; set; }

        public override string Path { get; set; }

        public override int LastId { get; set; }

        //конструктор
        public DoctorRepository(string appSetings, ISerializationService serializationService) : base (appSetings, serializationService)
        {
            this.SerializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine(); // implement view of all object fields
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            SerializationService.Serialize<Doctor>(AppSetings, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }
    }
}
