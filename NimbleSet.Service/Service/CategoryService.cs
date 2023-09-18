using Services.Dtos;
using Services.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.IRepositories;
using Domain.Entities;
using NimbleSet.Service.Exceptions;

namespace NimbleSet.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private long _id;
        private readonly IRepositoryAsync<Category> repositoryCategory = new Repository<Category>();
        public async Task<bool> RemoveAsync(long id)
        {
            var category = await repositoryCategory.SelecttByIdAsync(id);

            if (category is null)
                throw new CustomException(404, "Category is not found ");

            await repositoryCategory.DeleteAsync(id);

            return true;
        }

        public async Task<List<CategoryForRezultDto>> GetAllAsync()
        {
            List<Category> categories = new List<Category>();
            List<CategoryForRezultDto> mapCategories = new List<CategoryForRezultDto>();

            foreach (var category in categories)
            {
                CategoryForRezultDto rezultDto = new CategoryForRezultDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                mapCategories.Add(rezultDto);
            }
            return mapCategories;
        }

        public async Task<CategoryForRezultDto> GetByIdAsync(long id)
        {
            var category = await repositoryCategory.SelecttByIdAsync(id);

            if(category is null)
            {
                throw new CustomException(404, "Category is not null");
            }
            CategoryForRezultDto rezultDto = new CategoryForRezultDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
            return rezultDto;
        }

        public async Task<CategoryForRezultDto> CreateAsync(CategoryForCreationDto categoryDto)
        {
            var category = (await repositoryCategory.SelectAllAsync()).
                FirstOrDefault(c => c.Name.ToLower() == categoryDto.CategoryName);
            if(category != null)
            {
                throw new CustomException(409, "Category is already exist");
            }
            Category category1 = new Category
            {
                Id = _id,
                Name = categoryDto.CategoryName,
                CreatedAt = DateTime.UtcNow
            };
            await repositoryCategory.InsertAsync(category1);
            CategoryForRezultDto rezultDto = new CategoryForRezultDto()
            {
                Name = category1.Name,
                Id = category1.Id
            };
            return rezultDto;
        }

        public async Task<CategoryForRezultDto> UpdateAsync(CategoryForUpdateDto user)
        {
            var category = await repositoryCategory.SelecttByIdAsync(user.Id);
            if(category is  null)
                throw new CustomException(404,"Category is not found");
            var mapCategory = new Category()
            {
                Name = category.Name,
            };
            await repositoryCategory.UpdateAsync(mapCategory);
            var resultDto = new CategoryForRezultDto()
            {
                Id = user.Id,
                Name = category.Name,
            };
            return resultDto;
        }
        public async Task GenerateIdAsync()
        {
            var categories = await repositoryCategory.SelectAllAsync();
            if (categories.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var student = categories[categories.Count - 1];
                this._id = ++student.Id;
            }
        }
    }
}
