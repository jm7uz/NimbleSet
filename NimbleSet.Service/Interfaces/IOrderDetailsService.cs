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
        public Task<bool> DeleteAsync(long id);
        public Task<List<CategoryForRezultDto>> GetAllAsync();
        public Task<CategoryForRezultDto> GetByIdAsync(long id);
        public Task<CategoryForRezultDto> UpdateAsync(long orderId, long productId, long quantity);
        public Task<CategoryForRezultDto> InsertAsync(long orderId,long productId,long quantity );
    }
}
