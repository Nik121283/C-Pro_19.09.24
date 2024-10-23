using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class Repository
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public Configs Doctors {  get; set; }
        public Configs Appointments { get; set; }
        public Configs Patients { get; set; }
    }

    public class Configs 
    {
        public int LastId {  get; set; }
        public string Path { get; set; }
    }
}
