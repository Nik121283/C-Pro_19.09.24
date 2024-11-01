using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Domain.Enums;

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
            if (doctor != null)
            {
                Console.WriteLine(doctor);
            }
                
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            SerializationService.Serialize(AppSetings, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }

        public bool IncreaseSalary(int id, decimal addToSalary)
        {
            var doctor = base.GetById(id);

            if (doctor != null)
            {
                doctor.Salary += addToSalary;

                base.Update(id, doctor);

                return true;
            }

            return false;
        }

        public bool DecreaseSalary(int id, decimal addToSalary)
        {
            var doctor = base.GetById(id);

            if (doctor != null)
            {
                doctor.Salary -= addToSalary;

                base.Update(id, doctor);

                return true;
            }

            return false;
        }

        public List<Doctor> GetAllbyDoctorTypes(DoctorTypes doctorTypes)
        {
            return GetAll().Where(x => x.DoctorType == doctorTypes).ToList();
        }

    }
}
