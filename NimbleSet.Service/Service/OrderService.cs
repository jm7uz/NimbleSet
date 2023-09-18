using System;
using System.Linq;
using System.Text;
using Services.Dtos;
using Domain.Entities;
using Data.Repositories;
using Data.IRepositories;
using Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using NimbleSet.Service.Exceptions;

namespace NimbleSet.Service.Service
{
    public class OrderService : IOrderService
    {
        private long _id;
        private readonly IRepositoryAsync<Order> repositoryOrder = new Repository<Order>();
        public async Task GenerateIdAsync()
        {
            var orders = await repositoryOrder.SelectAllAsync();
            if (orders.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var student = orders[orders.Count - 1];
                this._id = ++student.Id;
            }
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var order = await repositoryOrder.SelecttByIdAsync(id);

            if (order is null)
                throw new CustomException(404, "Order is not found ");

            await repositoryOrder.DeleteAsync(id);

            return true;
        }
        public async Task<List<OrderForRezultDto>> GetAllAsync()
        {
            List<Order> orders = await repositoryOrder.SelectAllAsync();
            List<OrderForRezultDto> orderForRezultDtos = new List<OrderForRezultDto>();

            foreach (var order in orders)
            {
                OrderForRezultDto rezultDto = new OrderForRezultDto()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    OrderDate = order.CreatedAt
                };
                orderForRezultDtos.Add(rezultDto);
            }
            return orderForRezultDtos;
        }

        public async Task<OrderForRezultDto> GetByIdAsync(long id)
        {
            var order = await repositoryOrder.SelecttByIdAsync(id);
            if (order is null)
                throw new CustomException(404, "Order is not null");
            OrderForRezultDto orderForRezultDto = new OrderForRezultDto()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.CreatedAt
                
            };
            return orderForRezultDto;
        }

        public async Task<OrderForRezultDto> CreateAsync(long customerId)
        {
            Order order = new Order()
            {
                CustomerId = customerId,
            };
            OrderForRezultDto rezultDto = new OrderForRezultDto()
            {
                Id= order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.CreatedAt
            };
            return rezultDto;
        }

    }
}
