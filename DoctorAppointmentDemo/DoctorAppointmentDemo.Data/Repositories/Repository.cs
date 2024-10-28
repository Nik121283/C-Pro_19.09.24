using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class Repository
    {
        public Database? Database { get; set; }

        public Repository()
        {
            
        }
        public Repository(int doctorId, string doctorPath, int appointmentId, string appointmentPath, int patientId, string patientPath)
        {
            this.Database = new Database(doctorId, doctorPath, appointmentId, appointmentPath, patientId, patientPath);
        }
    }

    

    public class Database
    {
        public Configs Doctors {  get; set; }
        public Configs Appointments { get; set; }
        public Configs Patients { get; set; }

        public Database(int doctorId, string doctorPath, int appointmentId, string appointmentPath, int patientId, string patientPath)
        {
            this.Doctors = new Configs(doctorId, doctorPath);
            this.Appointments = new Configs(appointmentId, appointmentPath);
            this.Patients = new Configs(patientId, patientPath);
        }
        public Database()
        {
            
        }
    }

    public class Configs 
    {
        public int LastId {  get; set; }
        public string Path { get; set; }

        public Configs()
        {
            
        }

        public Configs(int id, string path)
        {
            LastId = id;
            Path = path;
        }
    }
}
