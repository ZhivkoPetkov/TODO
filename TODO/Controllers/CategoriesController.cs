using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Domains;
using TODO.Domains.Data;
using TODO.Services.Contracts;
using TODO.Utilities.DTOs;

namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(ApplicationDbContext context, IMapper mapper, ICategoryService categoryService)
        {
            _context = context;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategories()
        {
            var result = await this.categoryService.GetCategories();
            return result.ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category =await this.categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

   
        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await this.categoryService.AddCategory(category);

            return CreatedAtAction("GetCategoryById", new { id = result });
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            return await this.categoryService.DeleteCategory(id);
        }
    }
}
