using Lesson_2.Infrastructure.Models;
using System.Collections.Generic;

namespace Lesson_2.Infrastructure.Abstract
{
    public interface IUserService
    {
         List<User> GetUsers(); 
         User Create(User user);
         User Update(User user);
         User Delete(int id);
    }
}
