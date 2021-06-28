using EF.Core;
using EF.Core.Entities;
using EF.Core.IRepository;
using EF.Core.Specifications;
using EF.Data.Repository;
using EFlecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.BLL.Services
{
    public class DirectoryService
    {
        protected readonly IRepository<File> repository;
        protected readonly IRepository<Directory> dirRepository;

        public DirectoryService(IRepository<File> repository, IRepository<Directory> dirRepository)
        {
            this.repository = repository;
            this.dirRepository = dirRepository;
        }

        public async Task<string> AddAsync(Directory entity, CancellationToken cancellationToken = default)
        {
            var result = await this.dirRepository.AddAsync(entity, cancellationToken);
            return result;
        }
        public async Task<string> AddAsync(IEnumerable<Directory> entity, CancellationToken cancellationToken = default)
        {
            var result = await this.dirRepository.AddAsync(entity, cancellationToken);
            return result;
        }
        public async Task<string> RemoteAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.dirRepository.RemoveAsync(id, cancellationToken);
            return result;
        }
        public async Task<string> UpdateAsync(Directory entity, CancellationToken cancellationToken = default)
        {
            var result = await this.dirRepository.UpdateAsync(entity, cancellationToken);
            return result;
        }
        public async Task<PagedList<Directory>> GetAsync(Specification<Directory> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await this.dirRepository.GetAsync(specification, pageNumber, pageSize, cancellationToken);
        }
    }
}
