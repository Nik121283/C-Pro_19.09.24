﻿using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using System.Numerics;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(string appSettings, ISerializationService serializationService)
        {
            _appointmentRepository = new AppointmentRepository(appSettings, serializationService);
        }

        public bool Create(Appointment appointment)
        {

            return _appointmentRepository.Create(appointment);
        }

        public Appointment ItemEnterFromConsole(Doctor doctor, Patient patient)
        {

            Console.WriteLine("Введите время начала визита в формате DD.MM.YYYY");
            string input = Console.ReadLine();

            DateTime dateTimeFrom;
            DateTime dateTimeTo;

            while (true)
            {
                if (DateTime.TryParse(input,out dateTimeFrom))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы ввели недопустимое значение для даты");
                }

            }

            Console.WriteLine("Введите время окончания визита в формате DD.MM.YYYY");
            while (true)
            {
                
                input = Console.ReadLine();

                if (DateTime.TryParse(input, out dateTimeTo))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы ввели недопустимое значение");
                }
            }

            Console.WriteLine("Введите дополнительную информацию о визите");
            string additionalInfo = Console.ReadLine();


            //Patient patient, Doctor doctor, DateTime dateTimeFrom, DateTime dateTimeTo, string description
            Appointment newAppointment = new Appointment( patient, doctor, dateTimeFrom, dateTimeTo, additionalInfo);

            return newAppointment;
        }


        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public bool Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }

        public Appointment ItemEnterFromConsole()
        {
            throw new NotImplementedException();
        }
    }
}
