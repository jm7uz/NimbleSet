﻿using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Service
{
    public class OrderService : IOrderService
    {
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderForRezultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderForRezultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderForRezultDto> InsertAsync(long customerId, decimal totalAmaunt)
        {
            throw new NotImplementedException();
        }

        public Task<OrderForRezultDto> UpdateAsync(OrderForUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
