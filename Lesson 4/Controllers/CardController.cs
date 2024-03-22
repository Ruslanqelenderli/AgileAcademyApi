
using Lesson_4.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AppDbContext appContext;
        public CardController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        [HttpGet("cards")]
        public async Task<ActionResult<List<object>>> Get()
        {
            var query = appContext.Cards.Include(x => x.User).ThenInclude(d=>d.Role).Include(y => y.Product).Select(z => new
            {
                UserName = z.User.UserName,
                RoleName = z.User.Role.RoleName,
                ProductName = z.Product.ProductName
            });

            var querystring =query.ToQueryString();
            var result = await query.ToListAsync(); 
            //select u.UserName,p.ProductName from Card c
            //    inner join users u on c.UserId = u.Id
            //    inner join product p on c.ProductId = p.Id

            var query1 = from c in appContext.Cards
                        join u in appContext.Users on c.UserId equals u.Id
                        join p in appContext.Products on c.ProductId equals p.Id
                        join r in appContext.Roles on u.RoleId equals r.Id
                        select new
                        {
                            UserName = u.UserName,
                            RoleName = r.RoleName,
                            ProductName = p.ProductName
                        };
            var querystring2 = query1.ToQueryString();
            var result2 = await query1.ToListAsync();



            return Ok(result2) ;
        }
    }
}
