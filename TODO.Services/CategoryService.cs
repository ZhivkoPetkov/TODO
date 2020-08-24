using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Domains;
using TODO.Domains.Data;
using TODO.Services.Contracts;
using TODO.Utilities.DTOs;

namespace TODO.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public CategoryService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<int> AddCategory(Category category)
        {
            if (this.dbContext.Categories.Any(x => x.Name == category.Name))
            {
                return 0;
            }
            this.dbContext.Categories.Add(category);
            this.dbContext.SaveChanges();

            return category.Id;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category =  await this.dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null)
            {
                return false;
            }

            this.dbContext.Categories.Remove(category);
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<ICollection<CategoryDto>> GetCategories()
        {
            return this.mapper.Map<List<CategoryDto>>(this.dbContext.Categories.ToList());
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            return this.mapper.Map<CategoryDto>(await this.dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<CategoryDto> UpdateCategory(Category category)
        {
            this.dbContext.Categories.Update(category);
            this.dbContext.SaveChanges();

            return this.mapper.Map<CategoryDto>(category);
        }
    }
}
