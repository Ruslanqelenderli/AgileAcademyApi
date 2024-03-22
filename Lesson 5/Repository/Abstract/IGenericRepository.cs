using Lesson_5.Entities;

namespace Lesson_5.Repository.Abstract
{
    public interface IGenericRepository<T> 
        where T : BaseEntity,new()

    {
        List<T> GetAll();
        T GetById(int id);
        T DeleteSoft(int id);
        T DeleteHard(int id);
        T Update(T entity);
        T Create(T entity);
    }
}
