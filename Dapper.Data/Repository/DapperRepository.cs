using Dapper.Core.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core.Entities;
using System.Data;

namespace Dapper.Data
{
    public class DapperRepository : IRepository
    {
        string connectionString = @"Server=DESKTOP-BNTF795;Database=DapperPractisedb;Trusted_Connection=True";
        public async Task DeleteAsync<TEntity>(int id)
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync($"DELETE FROM [sch].[{type.Name}] WHERE Id=@Id", new { Id = id });
            }
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>()
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<TEntity>($"SELECT * FROM [sch].[{type.Name}]");
            }
        }

        public async Task<TEntity> GetAsync<TEntity>(int id)
        {
            var type = typeof(TEntity);
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryFirstAsync<TEntity>($"SELECT * FROM [sch].[{type.Name}] WHERE Id=@Id", new { id });
                return result;
            }
        }

        public async Task AddAsync<TEntity>(TEntity entity)
        {
            var insertQuery = GenerateInsertQuery<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(insertQuery, entity);
            }
        }

        public async Task UpdateAsync<TEntity>(TEntity entity)
        {
            var updateQuery = GenerateUpdateQuery<TEntity>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(updateQuery, entity);
            }
        }
        private string GenerateInsertQuery<TEntity>()
        {
            var type = typeof(TEntity);
            var insertQuery = new StringBuilder($"INSERT INTO [sch].[{type.Name}]");
            var getProperties = typeof(TEntity).GetProperties().Where(x => x.Name != "CountryCodes" && x.Name != "Orders" && x.Name != "Merchant" && x.Name != "Id" && x.Name != "User" && x.Name != "OrderItems").Select(x => x);
            insertQuery.Append("(");
            var properties = GenerateListOfProperties(getProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");
            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");
            return insertQuery.ToString();
        }
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
        private string GenerateUpdateQuery<TEntity>()
        {
            var type = typeof(TEntity);
            var updateQuery = new StringBuilder($"UPDATE [sch].[{type.Name}] SET ");
            var getProperties = typeof(TEntity).GetProperties().Where(x => x.Name != "CountryCodes" && x.Name != "Orders" && x.Name != "Merchant" && x.Name != "Id" && x.Name != "User" && x.Name != "OrderItems").Select(x => x); ;
            var properties = GenerateListOfProperties(getProperties);
            properties.ForEach(property =>
            {
                if (!property.Equals("UserId") && !property.Equals("CountryId") && !property.Equals("Country") && !property.Equals("Products"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");
            return updateQuery.ToString();
        }

    }
}
