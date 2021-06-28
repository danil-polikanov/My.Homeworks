using EF.Core.Entities;
using EF.Core.Specifications;
using EFlecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Core.IRepository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<string> AddAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);

        Task<string> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<string> RemoveAsync(int id, CancellationToken cancellationToken = default);

        Task<string> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task GetFilesFromDirectory(int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
