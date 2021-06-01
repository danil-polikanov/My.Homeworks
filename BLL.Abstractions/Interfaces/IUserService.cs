using Core.Models;
using System.Collections.Generic;

namespace BLL.Abstractions.Interfaces
{
    public interface IUserService
    {
        List<User> LoadRecords();
    }
}