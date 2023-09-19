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
    public class ProductService : IProductService
    {
        private long _id;
        private readonly IRepositoryAsync<Category> repositoryAsync = new RepositoryAsync<Category>();
        private readonly IRepositoryAsync<Product> productRepository = new RepositoryAsync<Product>();
        public async Task GenerateIdAsync()
        {
            var products = await productRepository.SelectAllAsync();
            if (products.Count == 0)
            {
                this._id = 1;
            }
            else
            {
                var product = products[products.Count - 1];
                this._id = ++product.Id;
            }
        }
        public async Task<bool> RemoveAsync(long id)
        {
            var product = await productRepository.SelecttByIdAsync(id);

            if (product is null)
                throw new CustomException(404, "Product is not found ");

            await productRepository.DeleteAsync(id);

            return true;
        }
        public async Task<List<ProductForRezultDto>> GetAllAsync()
        {
            List<Product> products = await productRepository.SelectAllAsync();
            List<ProductForRezultDto> productsForRezults = new List<ProductForRezultDto>();

            foreach (var product in products)
            {
                ProductForRezultDto productForRezultDto = new ProductForRezultDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    StockQuantity = product.StockQuantity,
                };
                productsForRezults.Add(productForRezultDto);
            }
            return productsForRezults;
        }
        public async Task<ProductForRezultDto> GetByIdAsync(long id)
        {
            var product = await productRepository.SelecttByIdAsync(id);
            if (product is null)
                throw new CustomException(404, "Product is not found");
            ProductForRezultDto productForRezult = new ProductForRezultDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
            };
            return productForRezult;
        }
        public async Task<ProductForRezultDto> UpdateAsync(ProductForUpdateDto productdto)
        {
            var product = await productRepository.SelecttByIdAsync(productdto.Id);
            if (product is null)
                throw new CustomException(404, "Product is not found");
            var mapProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                UpdatedAt = DateTime.UtcNow
            };
            await productRepository.UpdateAsync(mapProduct);
            var rezult = new ProductForRezultDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
            };
            return rezult;

        }
        public async Task<ProductForRezultDto> CreateAsync(ProductForCreationDto productdto)
        {
            var product = (await productRepository.SelectAllAsync()).
                FirstOrDefault(p => p.Name == productdto.Name);
            if (product != null)
            {
                throw new CustomException(409, "Product is already exist");
            }
            var productIfCategory = (await repositoryAsync.SelectAllAsync()).
                FirstOrDefault(c => c.Id == productdto.CategoryId);
            if (productIfCategory is not null)
            {
                throw new CustomException(404, "Category is not found");
            }
            Product product1 = new Product()
            {
                Id = _id,
                Name = productdto.Name, 
                Price = productdto.Price,
                CategoryId= productdto.CategoryId,
                Description = productdto.Description,
                StockQuantity = productdto.StockQuantity,

            };
            await productRepository.InsertAsync(product1);

            ProductForRezultDto productForRezult = new ProductForRezultDto()
            {
                Id = product1.Id,
                Name = product1.Name,
                Price = product1.Price,
                CategoryId = product1.CategoryId,
                Description = product1.Description,
                StockQuantity = product1.StockQuantity,
            };
            return productForRezult;
            
        }

    }
}
