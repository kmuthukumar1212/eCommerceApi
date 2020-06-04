using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext context;

        public ProductsController(ApiContext context)
        {
            this.context = context;
        }

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await context.Products.OrderBy(x => x.Id).ToListAsync();
        }
        
        // GET /api/products/category
        [HttpGet("{categoryName}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory(string categoryName)
        {
            Category category = await context.Categories.Where(x => x.Name == categoryName).FirstOrDefaultAsync();
            if (category == null) return NotFound();

            return await context.Products.OrderBy(x => x.Id).Where(x => x.CategoryId == category.Id).ToListAsync();
        }
    }
}
