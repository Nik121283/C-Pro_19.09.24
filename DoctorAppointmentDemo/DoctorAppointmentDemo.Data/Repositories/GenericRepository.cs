﻿using DoctorAppointmentDemo.Data.Interfaces;
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


        public TSource Create(TSource source)
        {
            
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var havingData = SerializationService.Deserialize<TSource>(Path);
            StringBuilder sb = new StringBuilder(havingData.ToString());


            SerializationService.Serialize<TSource>(Path, source);
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Formatting.Indented));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var json = File.ReadAllText(Path);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<TSource>>(json)!;
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Formatting.Indented));

            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();


        protected Repository ReadFromAppSettings() 
        {
            return SerializationService.Deserialize<Repository>(AppSetings);
        }


        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.JsonAppSettingsPath))!;
    }
}
