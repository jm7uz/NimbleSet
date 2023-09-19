using System;
using System.Linq;
using System.Text;
using Services.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<OrderForRezultDto>> GetAllAsync();
        public Task<OrderForRezultDto> GetByIdAsync(long id);
        public Task<OrderForRezultDto> CreateAsync(long customerId);
    }
}
