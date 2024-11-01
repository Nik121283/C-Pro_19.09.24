using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Text;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public string AppSetings { get; private set; }

        public abstract ISerializationService SerializationService { get; set; }

        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        protected GenericRepository(string appSetings, ISerializationService serializationService)
        {
            AppSetings = appSetings;
            SerializationService = serializationService;  
        }


        public bool Create(TSource source)
        {
            
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var havingData = GetAll();
            var newData = havingData.Append(source).ToList();

            SerializationService.Serialize(Path, newData);
            SaveLastId();

            return true;
        }

        public bool Delete(int id)
        {
            var checkById = GetById(id);

            if (checkById is null)
                return false;

            var havingData = GetAll();
            var newData = havingData.Where(x => x.Id != id).ToList();

            File.Delete(Path);

            SerializationService.Serialize(Path, newData);

            return true;
        }

        // возвращаем лист типа Т, если файла нет, создаем
        public List<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                return new List<TSource>();
            }

            return SerializationService.Deserialize<List<TSource>>(Path);
        }



        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }


        public bool Update(int id, TSource source)
        {

            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            var havingData = GetAll();

            havingData.Select(x => x.Id == id ? source : x) ;

            return true;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();


        protected Repository ReadFromAppSettings() 
        {

            try
            {
                return SerializationService.Deserialize<Repository>(AppSetings);
            }
            catch (Exception ex)
            {
                Repository repository = new Repository(
                    0,
                    "E:\\Обучение\\C#\\C# Hillel Pro 09.09.24\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\MockedDatabase\\doctors.xml",
                    0,
                    "E:\\Обучение\\C#\\C# Hillel Pro 09.09.24\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\MockedDatabase\\appointments.xml",
                    0,
                    "E:\\Обучение\\C#\\C# Hillel Pro 09.09.24\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\MockedDatabase\\patients.xml");

                SerializationService.Serialize<Repository>(AppSetings, repository);
                return repository;
            }
            
            
        }


        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.JsonAppSettingsPath))!;
    }
}
