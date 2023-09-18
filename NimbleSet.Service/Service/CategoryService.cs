using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Service
{
    public class CategoryService : ICategoryService
    {
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryForRezultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryForRezultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryForRezultDto> InsertAsync(CategoryForCreationDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryForRezultDto> UpdateAsync(CategoryForUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
