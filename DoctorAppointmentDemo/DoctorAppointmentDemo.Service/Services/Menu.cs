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
            string[] options = { "Выбрать XML формат", "Выбрать JSON формат", "Работать с базой Докторов", "Работать с базой Пациентов", "Работать с Записями", "Выход" };
            bool exit = false;

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
                                case 0: DoctorAppointment doctorAppointment1 = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService()); break;
                                case 1: DoctorAppointment doctorAppointment2 = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService()); break;
                                case 2:; break;
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
        private readonly IDoctorService _doctorService;

        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
        }
    }
}
