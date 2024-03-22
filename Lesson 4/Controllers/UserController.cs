
using Lesson_4.DTO;
using Lesson_4.EF;
using Lesson_4.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext appContext;
        public UserController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        [HttpGet("users")]
        public async Task<ActionResult<List<UserGetDto>>> Get()
        {
            var data =  await appContext.Users
                .Include(x=>x.Role)
                .ToListAsync();

            var data2 = await appContext.Users
                .Include(x => x.Role)
                .Select(y => new UserGetDto
                {
                    UserName = y.UserName,
                    RoleName = y.Role.RoleName
                })
                .ToListAsync();

            return data2;
        }
    }
}
