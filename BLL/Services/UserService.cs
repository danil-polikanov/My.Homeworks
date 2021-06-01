using BLL.Abstraction.Interfaces;
using DAL.Abstraction.Interfaces;

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
            _repository.LoadRecords();
        }
    }
}