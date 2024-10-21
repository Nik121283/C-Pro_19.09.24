using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface ISerializationService
    {
        public T Deserialize<T>(string path);

        public void Serialize<T>(string path, T dataSource);
    }
}
