using Lesson_2.Infrastructure.Abstract;
using Lesson_2.Infrastructure.Models;
using System.Collections.Generic;

namespace Lesson_2.Infrastructure.Concrete
{
    public class Manage : IManage
    {
        private readonly IUserService userService;
        public Manage(IUserService userService)
        {
            this.userService = userService;
        }
        public List<User> Method(User user)
        {
            userService.Create(user);
            return userService.GetUsers();  
        }
    }
}
