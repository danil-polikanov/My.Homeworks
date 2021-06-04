using Core.Models;
using System.Collections.Generic;

namespace BLL.Abstractions.Interfaces
{
    public interface IUserService
    {
        public List<User> LoadRecords();
    }
}