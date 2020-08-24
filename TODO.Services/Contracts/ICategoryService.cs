using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODO.Domains;
using TODO.Utilities.DTOs;

namespace TODO.Services.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategoryById(int id);
        Task<ICollection<CategoryDto>> GetCategories();
        Task<int> AddCategory(Category category);
        Task<CategoryDto> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
