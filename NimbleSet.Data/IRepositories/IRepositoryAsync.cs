using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface IRepositoryAsync<TEntity>
    {
        public Task<TEntity> InsertAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(long Id);
        public Task<TEntity> SelecttByIdAsync(long Id);
        public Task<List<TEntity>> SelectAllAsync();

    }
}
