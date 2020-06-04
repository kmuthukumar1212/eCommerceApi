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
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext context;

        public CategoriesController(ApiContext context)
        {
            this.context = context;
        }

        // GET /api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await context.Categories.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
