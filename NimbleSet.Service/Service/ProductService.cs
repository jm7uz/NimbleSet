using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Service
{
    public class ProductService : IProductService
    {
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductForRezultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductForRezultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductForRezultDto> InsertAsync(ProductForCreationDto user)
        {
            throw new NotImplementedException();
        }

        public Task<ProductForRezultDto> UpdateAsync(ProductForUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
