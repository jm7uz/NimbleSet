using Data.IRepositories;
using Data.Repositories;
using Domain.Entities;
using NimbleSet.Service.Exceptions;
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
        private readonly IRepositoryAsync<Order> orderRepository = new RepositoryAsync<Order>();
        private readonly IRepositoryAsync<OrderDetails> repositoryOrderDetails = new RepositoryAsync<OrderDetails>();
        public async Task<bool> RemoveAsync(long id)
        {
            var orderDeteils = await repositoryOrderDetails.SelecttByIdAsync(id);

            if (orderDeteils is null)
                throw new CustomException(404, "Product is not found ");

            await repositoryOrderDetails.DeleteAsync(id);

            return true;
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            List<OrderDetails> orderDeteils = await repositoryOrderDetails.SelectAllAsync();
            return  orderDeteils;
        }

        public async Task<List<OrderDetails>> GetByIdAsync(long customerId)
        {
            var  orders  = await orderRepository.SelectAllAsync();
            List<OrderDetails> orderDetailses = new List<OrderDetails>();

            foreach (var item in orders)
            {
                if (item.CustomerId == customerId)
                {
                    foreach (var item1 in orderDetailses)
                    {
                        if (item1.OrderId == item.Id)
                        {
                            orderDetailses.Add(item1);
                        }
                    }
                }
            }
            return orderDetailses;
        }

        public async Task<OrderDetails> CreateAsync(OrderDetails orderDetails)
        {
            OrderDetails orderDetails1 = new OrderDetails()
            {
                OrderId = orderDetails.OrderId,
                Id = _id,
                ProductId = orderDetails.ProductId,
                Quantity = orderDetails.Quantity,
            };
            await repositoryOrderDetails.InsertAsync(orderDetails1); 
            return orderDetails1;
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
