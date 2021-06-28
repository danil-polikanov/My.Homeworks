using EF.Data.Context;
using EF.Core.IRepository;
using EF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EF.Core.Specifications;
using EFlecture.Core.Models;
using EFLecture.Data.EFCore.Extentions;
using System.Linq.Expressions;
using EF.Core;

namespace EF.Data.Repository
{
    public class FileRepository : IRepository<File>
    {
        protected readonly EntityFrameworkPractiseDbContext context;
        protected readonly DbSet<File> entities;

        public FileRepository(EntityFrameworkPractiseDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<File>();
        }

        public async virtual Task<string> AddAsync(File entity, CancellationToken cancellationToken = default)
        {
            this.entities.Add(entity);
            await context.SaveChangesAsync();
            return "Done";
        }
        public async virtual Task<string> AddAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default)
        {
            this.entities.AddRange(entity);
            await context.SaveChangesAsync();
            return "Done";
        }

        public async virtual Task<string> RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            File deleteFile = await context.Files.FindAsync(id);
            File entity = deleteFile as File;
            this.entities.Remove(entity);
            await context.SaveChangesAsync();
            return "Done";
        }

        public async virtual Task<string> UpdateAsync(File entity, CancellationToken cancellationToken = default)
        {
            File changed = entity as File;
            File editFile = await context.Files.FindAsync(changed.Id);
            editFile.Extension = changed.Extension;
            editFile.Directories = changed.Directories;
            editFile.DirectoryId = changed.DirectoryId;
            editFile.FilePermissions = changed.FilePermissions;
            editFile.Size = changed.Size;
            editFile.Title = changed.Title;
            await context.SaveChangesAsync();
            return "Done";
        }       
        public async virtual Task<PagedList<File>> Get(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {

            var test = this.entities.Where(x => true);

            return await test.OfType<File>().Include(specification.Expression).ToPagedListAsync(pageNumber, pageSize);
        }
        public Task GetFilesFromDirectory(int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<PagedList<File>> GetAsync(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var files = this.entities.Where(x => true);
            if (specification.Сonditions != null)
            {
                foreach (var include in specification.Сonditions)
                {
                    files = files.Include(include);
                }
            }
            return await files.Where(specification.Expression).ToPagedListAsync(1, 20, cancellationToken); 
        }
    }
}

