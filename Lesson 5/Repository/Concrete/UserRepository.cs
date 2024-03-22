using Lesson_5.EF;
using Lesson_5.Entities;
using Lesson_5.Repository.Abstract;

namespace Lesson_5.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext):base(appDbContext)
        {
        }
    }
}
