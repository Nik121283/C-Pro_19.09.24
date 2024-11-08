using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using System;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(string appSettings, ISerializationService serializationService)
        {
            _doctorRepository = new DoctorRepository(appSettings, serializationService);
        }

        public bool Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public Doctor ItemEnterFromConsole()
        {
            Console.WriteLine("Введите имя доктора");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию доктора");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите телефон доктора");
            string phone = Console.ReadLine();

            Console.WriteLine("Введите имеил доктора");
            string email = Console.ReadLine();


            Console.WriteLine("Выберите тип доктора \nDentist = 1,\nDermatologist =2,\nFamilyDoctor=3,\nParamedic=4");
            string doctorsType = Console.ReadLine();

            if (Enum.TryParse(doctorsType, true, out DoctorTypes typeOfDoctor))
            {
                Console.WriteLine($"Вы выбрали: {typeOfDoctor}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }



            Console.WriteLine("Введите опыт врача");
            string expirience = Console.ReadLine();
            byte expirienceResult;

            if (byte.TryParse(expirience, out expirienceResult))
            {
                Console.WriteLine($"Вы ввели: {expirienceResult}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            Console.WriteLine("Введите зарплату врача");
            string salary = Console.ReadLine();
            decimal salaryResult;

            if (decimal.TryParse(salary, out salaryResult))
            {
                Console.WriteLine($"Вы ввели: {salaryResult}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            Doctor newDoctor = new Doctor(name, surname, phone, email, typeOfDoctor, expirienceResult, salaryResult);

            return newDoctor;
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public bool Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }

        public bool IncreaseSalaryById(int id, decimal addToSalary)
        {
            return _doctorRepository.IncreaseSalary(id, addToSalary);
        }

        public bool DecreaseSalaryById(int id, decimal addToSalary)
        {
            return _doctorRepository.DecreaseSalary(id, addToSalary);
        }

        public Doctor ItemEnterFromConsole(Doctor doctor, Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
