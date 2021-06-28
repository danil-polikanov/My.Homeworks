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
    public class FileService
    {
        protected readonly IRepository<File> repository;
        protected readonly IRepository<Directory> dirRepository;

        public FileService(IRepository<File> repository, IRepository<Directory> dirRepository)
        {
            this.repository = repository;
            this.dirRepository = dirRepository;
        }

        public async Task<string> AddAsync(File entity, CancellationToken cancellationToken = default)
        {
            var result = await this.repository.AddAsync(entity, cancellationToken);
            return result;
        }
        public async Task<string> AddAsync(IEnumerable<File> entity, CancellationToken cancellationToken = default)
        {
            var result = await this.repository.AddAsync(entity, cancellationToken);
            return result;
        }
        public async Task<string> RemoteAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await this.repository.RemoveAsync(id, cancellationToken);
            return result;
        }
        public async Task<string> UpdateAsync(File entity, CancellationToken cancellationToken = default)
        {
            var result = await this.repository.UpdateAsync(entity, cancellationToken);
            return result;
        }
        public async Task<PagedList<File>> GetAsync(Specification<File> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await this.repository.GetAsync(specification, pageNumber, pageSize, cancellationToken);
        }
        public async Task<PagedList<File>> GetFilesWhichCanRead(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<File, object>>>();
            conditions.Add(z => z.FilePermissions.Where(x => x.CanRead && x.UserId == userId));
            return await this.GetAsync(new Specification<File>(x => x.DirectoryId == directoryId, conditions), pageNumber, pageSize, cancellationToken);
        }
        public async Task<List<Entity>> GetFilesFromDirectory(Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<Directory, object>>>();
            var directories = dirRepository.GetAsync(new Specification<Directory>(
                    x => x.Id == directory.Id,
                    conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var files = repository.GetAsync(new Specification<File>(x => x.DirectoryId == directory.Id), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var result = new List<Entity>();
            result.AddRange(directories);
            result.AddRange(files);
            return await Task.FromResult(result);
        }
        public async Task<List<string>> GetDirectoryFullName(Directory directory, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<Directory, object>>>();
            var directories = dirRepository.GetAsync(new Specification<Directory>(
                    x => x.Id > 0,
                    conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var files = repository.GetAsync(new Specification<File>(x => x.DirectoryId == directory.Id), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var FullName = new List<string>();
            int? temp = 0;

            var Name = dirRepository.GetAsync(new Specification<Directory>(
                    x => x.Id == directory.Id,
                    conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            while (true)
            {
                foreach (var i in Name)
                {
                    FullName.Add(i.Title);

                    temp = i.ParentDirectoryId;
                }
                if (Name.Any(x => x.ParentDirectoryId == null))
                    break;
                Name = dirRepository.GetAsync(new Specification<Directory>(
                x => x.Id == temp,
                conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            }
            FullName.Add("\\");
            FullName.Reverse();
            return await Task.FromResult(FullName);
        }
        public async Task<List<Entity>> GetAllCanOpen(int userId,int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<File, object>>>();
            conditions.Add(z => z.FilePermissions.Where(x => x.CanRead && x.UserId == userId));
            var dirconditions = new List<Expression<Func<Directory, object>>>();
            dirconditions.Add(z => z.DirectoryPermissions.Where(x => x.CanRead && x.UserId == userId));
            var directories = dirRepository.GetAsync(new Specification<Directory>(x=>x.Id==directoryId,
                    dirconditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();

            var files = repository.GetAsync(new Specification<File>(x => x.DirectoryId == directoryId, conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            var result = new List<Entity>();
            result.AddRange(directories);
            result.AddRange(files);
            return await Task.FromResult(result);      
        }
        public async Task<List<int>> CountOfFiles(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<File, object>>>();

            var availableFiles= repository.GetAsync(new Specification<File>(x => x.DirectoryId == directoryId, conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            
            conditions.Add(z => z.FilePermissions.Where(x => x.CanRead && x.UserId == userId));

            var files = repository.GetAsync(new Specification<File>(x => x.DirectoryId == directoryId, conditions), pageNumber, pageSize, cancellationToken).Result.Items.ToList();
            int allFilesCount = files.Count();
            int availableFilesCount = availableFiles.Count();

            var result = new List<int>();
            result.Add(allFilesCount);
            result.Add(availableFilesCount);
            return await Task.FromResult(result);
        }
        public async Task<PagedList<File>> SortFiles (int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var conditions = new List<Expression<Func<File, object>>>();

            return await this.GetAsync(new Specification<File>(x=>x.Id>0, conditions), pageNumber, pageSize, cancellationToken);
        }
    }
}


