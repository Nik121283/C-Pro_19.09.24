using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {

        bool Create(TSource source);

        TSource? GetById(int id);

        bool Update(int id, TSource source);

        IEnumerable<TSource> GetAll();

        bool Delete(int id);
    }
}
