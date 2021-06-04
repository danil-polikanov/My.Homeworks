using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public List<User> LoadRecords()
        {
            return _repository.LoadRecords();
        } 
    }
}