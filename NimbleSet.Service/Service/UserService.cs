using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Service.Service
{
    public class UserService : IUserService
    {
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserForRezultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserForRezultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserForRezultDto> InsertAsync(UserForCreationDto user)
        {
            throw new NotImplementedException();
        }

        public Task<UserForRezultDto> UpdateAsync(UserForUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
