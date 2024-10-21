using DoctorAppointmentDemo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.Services
{
    public class XmlDataSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream filstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)xmlSerializer.Deserialize(filstream);
            }
        }

        public void Serialize<T>(string path, T dataSource)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using(FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, dataSource);
            }
        }
    }
}
