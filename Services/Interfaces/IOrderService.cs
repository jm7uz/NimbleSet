using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> DeleteAsync(long id);
        public Task<List<OrderForRezultDto>> GetAllAsync();
        public Task<OrderForRezultDto> GetByIdAsync(long id);
        public Task<OrderForRezultDto> UpdateAsync(OrderForUpdateDto user);
        public Task<OrderForRezultDto> InsertAsync(long customerId,decimal totalAmaunt);
    }
}
