using Lesson_2.Infrastructure.Models;
using System.Collections.Generic;

namespace Lesson_2.Infrastructure.Abstract
{
    public interface IManage
    {
        List<User> Method(User user); 
    }
}
