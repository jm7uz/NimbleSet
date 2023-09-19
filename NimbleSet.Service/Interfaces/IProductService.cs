using System;
using System.Linq;
using System.Text;
using Services.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IProductService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<ProductForRezultDto>> GetAllAsync();
        public Task<ProductForRezultDto> GetByIdAsync(long id);
        public Task<ProductForRezultDto> UpdateAsync(ProductForUpdateDto user);
        public Task<ProductForRezultDto> CreateAsync(ProductForCreationDto user);
    }
}
