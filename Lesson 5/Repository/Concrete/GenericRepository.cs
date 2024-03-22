using Lesson_5.EF;
using Lesson_5.Entities;
using Lesson_5.Repository.Abstract;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace Lesson_5.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity, new()
    {
        private readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public T Create(T entity)
        {
            appDbContext.Set<T>().Add(entity);
            appDbContext.SaveChanges();
            return entity;
        }

        public T DeleteHard(int id)
        {

            var data = appDbContext.Set<T>().FirstOrDefault(x=>x.Id.Equals(id));

            appDbContext.Set<T>().Remove(data);
            appDbContext.SaveChanges();
            return data;
        }

        public T DeleteSoft(int id)
        {
            var data = appDbContext.Set<T>().FirstOrDefault(x => x.Id.Equals(id));
            data.IsDeleted = true;
            appDbContext.Set<T>().Entry(data).State = EntityState.Modified;
            appDbContext.SaveChanges();
            return data;
        }

        public List<T> GetAll()
        {
            var datas = appDbContext.Set<T>().ToList();
            return datas;
        }

        public T GetById(int id)
        {
            var data = appDbContext.Set<T>().FirstOrDefault(x => x.Id.Equals(id));
            return data;
        }

        public T Update(T entity)
        {
            appDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            appDbContext.SaveChanges();
            return entity;
        }
    }
}
