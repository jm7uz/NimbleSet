using System;
using System.Text;
using System.Linq;
using Services.Dtos;
using Domain.Entities;
using Data.Repositories;
using Data.IRepositories;
using Services.Interfaces;
using System.Threading.Tasks;
using NimbleSet.Service.Dtos;
using System.Collections.Generic;
using NimbleSet.Service.Exceptions;

namespace NimbleSet.Service.Service
{
    public class UserService : IUserService
    {
        private long _id;
        private readonly IRepositoryAsync<User> userRepository = new RepositoryAsync<User>();
        public async Task GenerateIdAsync()
        {
            var users = await userRepository.SelectAllAsync();
            if (users.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var user = users[users.Count - 1];
                this._id = ++user.Id;
            }
        }
        public async Task<bool> RemoveAsync(long id)
        {
            var user = userRepository.SelecttByIdAsync(id);
            if (user != null)
                throw new CustomException(404,"User is not found");
            await userRepository.DeleteAsync(id);

            return true;
        }
        public async Task<List<UserForRezultDto>> GetAllAsync()
        {
            List<User> users = await userRepository.SelectAllAsync();
            List<UserForRezultDto> userForRezultDtos = new List<UserForRezultDto>();
            foreach (var user in users)
            {
                UserForRezultDto rezultDto = new UserForRezultDto()
                {
                    Id = user.Id,
                    roll = user.roll,
                    Email = user.Email,
                    Password = user.Password,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    PhoneNumber = user.PhoneNumber,
                };
                userForRezultDtos.Add(rezultDto);
            }
            return userForRezultDtos;
        }
        public async Task<UserForRezultDto> GetByIdAsync(long id)
        {
            var user = await userRepository.SelecttByIdAsync(id);
            if (user is null)
                throw new CustomException(404,"User is not found");
            var userResultDto = new UserForRezultDto()
            {
                Id = user.Id,
                roll = user.roll,
                Email = user.Email,
                Password = user.Password,
                LastName = user.LastName,
                FirstName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
            };
            return userResultDto;
        }
        public async Task<UserForRezultDto> UpdateAsync(UserForUpdateDto userCreationDto)
        {
            var user = await userRepository.SelecttByIdAsync(userCreationDto.Id);
            if (user is  null)
                throw new CustomException(404,"User is not found");
            var user1 = new User()
            {
                Email = userCreationDto.Email,
                FirstName = userCreationDto.FirstName,
                LastName = userCreationDto.LastName,
                Password = userCreationDto.Password,
                PhoneNumber = userCreationDto.PhoneNumber,
                UpdatedAt = DateTime.UtcNow
            };
            await userRepository.UpdateAsync(user1);
            var userResult = new UserForRezultDto()
            {
                Id = user1.Id,
                Email = user1.Email,
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Password = user1.Password,
                PhoneNumber = user1.PhoneNumber,
                roll = user1.roll
            };
            return userResult;
        }
        public async Task<UserForRezultDto> CreateAsync(UserForCreationDto userCreationDto)
        {
            var user =(await userRepository.SelectAllAsync()).
                FirstOrDefault(u => u.Email == userCreationDto.Email);
            if (user is not null)
                throw new CustomException(409, "User is already exist");
            User user1 = new User()
            {

                Id = _id,
                Email = userCreationDto.Email,
                FirstName = userCreationDto.FirstName,
                LastName = userCreationDto.LastName,
                Password = userCreationDto.Password,
                PhoneNumber = userCreationDto.PhoneNumber,
            };
            await userRepository.InsertAsync(user1);
            UserForRezultDto userForRezultDto = new UserForRezultDto()
            {
                Id = user1.Id,
                roll = user1.roll,
                Email = user1.Email,
                LastName = user1.LastName,
                Password = user1.Password,
                FirstName = user1.FirstName,
                PhoneNumber = user1.PhoneNumber,
            };
            return userForRezultDto;
        }
        public async Task<UserForRezultDto> UpdateRollAsync(UserForRollUpdate rollUpdate)
        {
            var user = userRepository.SelecttByIdAsync(rollUpdate.Id);
            if (user is null)
                throw new CustomException(404, "User is not found");
            User user1 = new User()
            {
                roll = rollUpdate.Roll,
                UpdatedAt = DateTime.UtcNow,
            };
            UserForRezultDto userForRezult = new UserForRezultDto()
            {
                Id = user1.Id,
                Email = user1.Email,
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Password = user1.Password,
                PhoneNumber = user1.PhoneNumber,
                roll = rollUpdate.Roll,
            };
            return userForRezult;
        }
    }
}
