using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
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
        public static DoctorAppointment doctorAppointment = null;

        public static void Start1()
        {
            int selectedOptions = 0;
            string[] options = { "XML база",
                                 "Json база",
                                 "Выход" };
            bool exit = false;

            ISerializationService chosedSerializeService = null;
            string appSettingsPath = string.Empty;

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
                //"Показать всех докторов. XML база",   0
                //"Показать всех докторов. Json база",  1
                //"Выход"                               2

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
                            case 0:
                                doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                                Start2(doctorAppointment);
                                break;

                            case 1:
                                doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                                Start2(doctorAppointment);
                                break;

                            case 2: exit = true; break;
                        }
                        break;
                }
            }
        }




        public static void Start2(DoctorAppointment doctorAppointment)
        {
            int selectedOptions = 0;
            string[] options = {     "База докторов",
                                     "База пациентов",
                                     "База записей на прием",
                                     "Выход в главное меню" };
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
                //"База докторов",         0
                //"База пациентов",        1
                //"База записей на прием", 2
                //"Выход в главное меню"   3

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
                            case 0:
                                Start3<Doctor>("Меню базы Докторов", doctorAppointment._doctorService);
                                break;

                            case 1:
                                Start3<Patient>("Меню базы Пациентов", doctorAppointment._patientService);
                                break;

                            case 2:
                                Start3<Appointment>("Меню базы Записей на прием", doctorAppointment._iAppointmentService);
                                break;

                            case 3: exit = true; Start1(); break;
                        }
                        break;
                }
            }

        }

        public static void Start3<T> (string header, IServiceInterface<T> chosedBase)  
        {
            int selectedOptions = 0;
            string[] options = {     "Создать",
                                     "Показать всех имеющихся в базе",
                                     "Показать по Id",
                                     "Удалить по Id",
                                     "Изменить по Id",
                                     "Выход в меню выше" };
            bool exit = false;


            while (!exit)
            {
                Console.Clear();

                Console.WriteLine(header);

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

                                     //"Создать",                            0
                                     //"Показать всех имеющихся в базе",     1
                                     //"Показать по Id",                     2
                                     //"Удалить по Id",                      3
                                     //"Изменить по Id",                     4
                                     //"Выход в меню выше"                   5

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
                            case 0:
                                chosedBase.Create(T newEntity);
                                break;

                            case 1:
                                chosedBase.GetAll();
                                break;

                            case 2:
                                chosedBase.Get(chosedBase.GetId());
                                break;

                            case 3:
                                chosedBase.Delete(chosedBase.GetId());
                                break;

                            case 4:
                                chosedBase.Update(chosedBase.GetId(), T newEntity);
                                break;

                            case 5: exit = true; Start2(doctorAppointment); break;
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
        public readonly IAppointmentService _iAppointmentService;


        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
            _patientService = new PatientService(appSettings, serializationService);
            _iAppointmentService = new AppointmentService(appSettings, serializationService);
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
