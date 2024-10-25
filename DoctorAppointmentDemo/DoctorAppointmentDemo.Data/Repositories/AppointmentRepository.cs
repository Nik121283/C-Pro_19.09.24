using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override ISerializationService SerializationService { get; set; }

        public override string Path { get; set; }

        public override int LastId { get; set; }

        //конструктор
        public AppointmentRepository(string appSetings, ISerializationService serializationService) : base(appSetings, serializationService)
        {
            this.SerializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            if (appointment != null)
            {
                Console.WriteLine(appointment);
            }
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            SerializationService.Serialize(AppSetings, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());

        }
    }
}
