using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {

        public bool Create(TSource source);

        public TSource? GetById(int id);

        public bool Update(int id, TSource source);

        public List<TSource> GetAll();

        public bool Delete(int id);
    }
}
