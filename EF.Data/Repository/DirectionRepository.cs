using EF.Core.Entities;
using EF.Core.IRepository;
using EF.Core.Specifications;
using EF.Data.Context;
using EFlecture.Core.Models;
using EFLecture.Data.EFCore.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Data.Repository
{
    public class DirectoryRepository: IRepository<Directory>
    {
        protected readonly EntityFrameworkPractiseDbContext context;
        protected readonly DbSet<Directory> entities;
        public DirectoryRepository(EntityFrameworkPractiseDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<Directory>();
        }

        public Task<string> AddAsync(IEnumerable<Directory> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddAsync(Directory entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Directory>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<PagedList<Directory>> GetAsync(Specification<Directory> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var files = this.entities.Where(x => true);
            if (specification.Сonditions != null)
            {
                foreach (var condition in specification.Сonditions)
                {
                    files = files.Include(condition);
                }
            }
            return await files.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }
        public Task GetFilesFromDirectory(int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<File>> GetFilesWhichCanRead(Specification<Directory> specification, int userId,int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(Directory entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
