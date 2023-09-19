using System;
using System.Text;
using System.Linq;
using Services.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserService
    {

        public Task<bool> RemoveAsync (long id);
        public Task<List<UserForRezultDto>> GetAllAsync();
        public Task<UserForRezultDto> GetByIdAsync(long id);
        public Task<UserForRezultDto> UpdateAsync(UserForUpdateDto user);
        public Task <UserForRezultDto>  CreateAsync (UserForCreationDto user);
    }
}
