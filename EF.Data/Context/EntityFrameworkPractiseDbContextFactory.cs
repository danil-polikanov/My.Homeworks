using EF.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFLecture.Data.EFCore.Contexts
{
    internal class EntityFrameworkPractiseDbContextFactory : IDesignTimeDbContextFactory<EntityFrameworkPractiseDbContext>
    {
        public EntityFrameworkPractiseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EntityFrameworkPractiseDbContext>()
                .UseSqlServer(@"Server=DESKTOP-BNTF795;Database=EntityPractiseDb;Trusted_Connection=True;",
                    o =>
                    {
                      
                        o.MigrationsHistoryTable("Migrations", "sch");
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    }).EnableSensitiveDataLogging();

            return new EntityFrameworkPractiseDbContext(optionsBuilder.Options);
        }
    }
}
