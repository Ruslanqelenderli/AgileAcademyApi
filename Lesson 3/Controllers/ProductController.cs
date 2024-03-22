using Lesson_3.EF;
using Lesson_3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext dbContext;
        public ProductController(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //private readonly IApllicationContext _context;
        //public ProductController(IApllicationContext _context)
        //{
        //     this._context = _context;
        //}

        [HttpGet("get")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var result = await dbContext.Products.ToListAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPost("add")]
        public async Task<ActionResult> Add(Product product)
        {
            try
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(Product product)
        {
            try
            {

            
                dbContext.Products.Update(product);
                await dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete (Product product)
        {
            try
            {

                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
