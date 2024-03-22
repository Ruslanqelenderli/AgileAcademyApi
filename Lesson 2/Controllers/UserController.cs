using Lesson_2.Infrastructure.Abstract;
using Lesson_2.Infrastructure.Concrete;
using Lesson_2.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        private readonly IManage manage;


        public UserController(IUserService userService, IManage manage,IConfiguration configuration)
        {
            this.userService = userService;
            this.manage = manage;
            this.configuration = configuration;
        }


        [HttpGet("Get")]
        public ActionResult<List<User>> GetUsers()
        {
            string value = configuration.GetSection("Logging:LogLevel:Default").Value;
            var users = userService.GetUsers();
            if (users.Count > 0) return Ok(users);
            return BadRequest();
        }


        [HttpPost("Create")]
        public User Create(User user,string id)
        {

            var request = Request;
            var response = Response;
            var httpContext = HttpContext;
            return userService.Create(user);

        }

        [HttpPut("Update")]
        public User Update(User user)
        {
            return userService.Update(user);
        }


        [HttpGet("Delete")]
        public User Delete(int id,string name,string surname)
        {
            int value = int.Parse(name);    
            return userService.Delete(id);
        }

        //[HttpPost("CreateAndGet")]
        //public List<User> CreateAndGet(User user)
        //{
        //     return manage.Method(user);
        //}


    }


    
}
