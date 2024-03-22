using Lesson_5.EF;
using Lesson_5.Entities;
using Lesson_5.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Lesson_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            var users = userRepository.GetAll();
            return users;   
        }
        [HttpPost("Create")]
        public async Task<User> Create(User user)
        {
            var result =userRepository.Create(user);
            return result;

        }

        [HttpDelete("DeleteSoft")]
        public async Task<User> Create(int id)
        {
            var result = userRepository.DeleteSoft(id);
            return result;

        }

    }
}
