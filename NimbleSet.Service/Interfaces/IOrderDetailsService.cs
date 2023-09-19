using Domain.Entities;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderDetailsService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<OrderDetails>> GetAllAsync();
        public Task<List<OrderDetails>> GetByIdAsync(long customerId);
        public Task<OrderDetails> CreateAsync(OrderDetails orderDetails );
    }
}
