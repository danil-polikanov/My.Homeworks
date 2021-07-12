using Dapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.IRepository
{
     public interface IRepository
    {
        Task<TEntity> GetAsync<TEntity>(int id);
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>();
        Task DeleteAsync<TEntity>(int id);
        Task UpdateAsync<TEntity>(TEntity t);
        Task AddAsync<TEntity>(TEntity t);
    }
}
