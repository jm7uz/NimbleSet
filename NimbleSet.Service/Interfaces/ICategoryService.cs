using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<CategoryForRezultDto>> GetAllAsync();
        public Task<CategoryForRezultDto> GetByIdAsync(long id);
        public Task<CategoryForRezultDto> UpdateAsync(CategoryForUpdateDto user);
        public Task<CategoryForRezultDto> CreateAsync(CategoryForCreationDto categoryDto);
    }
}
