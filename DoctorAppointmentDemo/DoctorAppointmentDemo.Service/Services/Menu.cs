using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Services
{
    public static class Menu
    {
        public static void Start()
        {
            int selectedOptions = 0;
            string[] options = { "Выбрать XML формат", "Выбрать JSON формат", "Показать всех Докторов", "Работать с базой Пациентов", "Работать с Записями", "Выход" };
            bool exit = false;

            DoctorAppointment doctorAppointment = null;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("---- Главное меню ----");

                for (int i = 0; i < options.Length; i++)
                {
                    if (selectedOptions == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"{i + 1}. {options[i]}");
                    Console.ResetColor();
                }

                // читаем нажатие клавиши
                ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        // если нажимаем вверх при текущем курсоре в 0, то переходим на самую нижнюю строку, если курсор в середине, то поднимаемся на 1 строку вверх
                        case ConsoleKey.UpArrow:
                            if (selectedOptions == 0) { selectedOptions = options.Length - 1; }
                            else { selectedOptions = selectedOptions - 1; }
                            break;

                        // если нажимаем вверх при текущем курсоре в 0, то переходим на самую нижнюю строку, если курсор в середине, то поднимаемся на 1 строку вверх
                        case ConsoleKey.DownArrow:
                            if (selectedOptions == options.Length - 1) { selectedOptions = 0; }
                            else { selectedOptions = selectedOptions + 1; }
                            break;

                        case ConsoleKey.Enter:
                            switch (selectedOptions)
                            {
                                case 0: doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService()); break;
                                case 1: doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService()); break;
                                case 2: doctorAppointment.ShowDoctors(); break;
                                case 3:; break;
                                case 4:; break;
                                case 5: exit = true; break;
                            }
                            break;
                    }
            }
        }

    }


    public class DoctorAppointment
    {
        public readonly IDoctorService _doctorService;
        public readonly IPatientService _patientService;

        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
            _patientService = new PatientService(appSettings, serializationService);
        }

        public void ShowDoctors()
        {
            var result = _doctorService.GetAll();

            foreach ( var item in result )
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
