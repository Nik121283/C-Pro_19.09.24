﻿using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Services
{
    public class JsonDataSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Serialize<T>(string path, T dataSource)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(dataSource, Formatting.Indented));
        }
    }
}
