using Data.IRepositories;
using Domain.Commons;
using Domain.Entities;
using Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : AudiTable
    {
        private readonly string Path;
        public Repository()
        {
            if (typeof(User) == typeof(TEntity))
            {
                Path = DatabasePath.UserDb;
            }
            if (typeof(Product) == typeof(TEntity))
            {
                Path = DatabasePath.ProductDb;
            }
            if (typeof(Category) == typeof(TEntity))
            {
                Path = DatabasePath.CategoryDb;
            }
            if (typeof(Order) == typeof(TEntity))
            {
                Path = DatabasePath.OrderDb;
            }
            if (typeof(OrderDetails) == typeof(TEntity))
            {
                Path = DatabasePath.OrderDetailsDb;
            }
            var str = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(str))
                File.WriteAllText(Path, "[]");
        }
        public async Task<bool> DeleteAsync(long Id)
        {
            var entities = await SelectAllAsync();
            var entity = entities.FirstOrDefault(e => e.Id == Id);
            entities.Remove(entity);
            var str = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(Path, str);
            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            string str = await File.ReadAllTextAsync(Path);
            List<TEntity> entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            entities.Add(entity);
            string result = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);
            return entity;
        }

        public async Task<List<TEntity>> SelectAllAsync()
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            return entities;
        }

        public async Task<TEntity> SelecttByIdAsync(long Id)
        {
            return (await SelectAllAsync()).FirstOrDefault(e => e.Id == Id);

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entities = await SelectAllAsync();
            await File.WriteAllTextAsync(Path, "[]");

            foreach (var data in entities)
            {
                if (data.Id == entity.Id)
                {
                    await InsertAsync(entity);
                    continue;
                }
                await InsertAsync(data);
            }

            return entity;
        }
    }
}
