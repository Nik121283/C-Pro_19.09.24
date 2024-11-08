using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using System.Net;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(string appSettings, ISerializationService serializationService)
        {
            _patientRepository = new PatientRepository(appSettings, serializationService);
        }

        public bool Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }


        public Patient ItemEnterFromConsole()
        {
            Console.WriteLine("Введите имя пациента");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию пациента");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите телефон пациента");
            string phone = Console.ReadLine();

            Console.WriteLine("Введите имеил email");
            string email = Console.ReadLine();


            Console.WriteLine("Выберите тип болезни \nEyeDisease = 1,\nInfection,\nDentalDisease,\nSkinDisease,\nAmbulance,");
            string deceaseType = Console.ReadLine();

            if (Enum.TryParse(deceaseType, true, out IllnessTypes deceaseTypeResult))
            {
                Console.WriteLine($"Вы выбрали: {deceaseType}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }


            Console.WriteLine("Введите дополнительную информацию о пациенте");
            string additionalInfo = Console.ReadLine();

            Console.WriteLine("Введите адрес пациента");
            string address = Console.ReadLine();

            //string name, string surname, string phone, string email, IllnessTypes illnessTypes, string additionalInfo, string address
            Patient newPatient = new Patient(name, surname, phone, email, deceaseTypeResult, additionalInfo, address);

            return newPatient;
        }



        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public bool Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

        public Patient ItemEnterFromConsole(Doctor doctor, Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
