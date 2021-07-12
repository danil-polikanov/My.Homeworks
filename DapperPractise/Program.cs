using Dapper.BLL;
using Dapper.Core.Entities;
using Dapper.Data;
using Dapper.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DapperPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            Context db = new Context();
            DapperRepository repository = new DapperRepository();
            Service service = new Service(repository);

        }
    }
}
