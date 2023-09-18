using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Service
{
    public class OrderDetailsService : IOrderDetailsService
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

        public Task<CategoryForRezultDto> InsertAsync(long orderId, long productId, long quantity)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryForRezultDto> UpdateAsync(long orderId, long productId, long quantity)
        {
            throw new NotImplementedException();
        }
    }
}
