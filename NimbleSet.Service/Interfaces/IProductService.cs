using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        public Task<bool> DeleteAsync(long id);
        public Task<List<ProductForRezultDto>> GetAllAsync();
        public Task<ProductForRezultDto> GetByIdAsync(long id);
        public Task<ProductForRezultDto> UpdateAsync(ProductForUpdateDto user);
        public Task<ProductForRezultDto> InsertAsync(ProductForCreationDto user);
    }
}
