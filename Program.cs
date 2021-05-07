using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using System.Collections.Generic;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            var DbEntity = new Dictionary<int, IDbEntity>();
            var dbServices = new InMemoryDatabaseService(DbEntity);
            var userStore = new UserStore(dbServices);
            var commands = new Dictionary<int, ICommand>();
            var addUsers = new AddUserCommand(userStore);
            var listUsers = new ListUsersCommand(userStore);

            commands.Add(addUsers.Number, addUsers);
            commands.Add(listUsers.Number, listUsers);
            var commandProcessor = new CommandProcessor(commands);
            var manager = new CommandManager(commandProcessor);
            manager.Start();
        }
    }
}
