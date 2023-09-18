using Data.IRepositories;
using Data.Repositories;
using Domain.Entities;
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

        private long _id;
        private readonly IRepositoryAsync<OrderDetails> repositoryOrderDetails = new Repository<OrderDetails>();
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
        public async Task GenerateIdAsync()
        {
            var orderDetailses = await repositoryOrderDetails.SelectAllAsync();
            if (orderDetailses.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var orderDetails = orderDetailses[orderDetailses.Count - 1];
                this._id = ++orderDetails.Id;
            }
        }
    }
}
