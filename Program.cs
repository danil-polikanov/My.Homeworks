using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.PL;
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
            var commandProcessor = new CommandProcessor(userStore, commands);
            var manager = new CommandManager(commandProcessor);
            manager.Start();
        }
    }
}
