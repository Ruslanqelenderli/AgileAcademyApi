using Lesson_2.Infrastructure.Abstract;
using Lesson_2.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_2.Infrastructure.Concrete
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>();

        public User Create(User user)
        {
            _users.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            var user = _users.FirstOrDefault(x=>x.Id == id);

            _users.Remove(user);
            return user;

        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User Update(User user)
        {
            var userModel = _users.FirstOrDefault(x=>x.Id == user.Id);
            userModel.Name = user.Name; 
            return userModel;
        }
    }
}
