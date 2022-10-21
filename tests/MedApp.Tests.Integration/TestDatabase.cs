using MedApp.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Tests.Integration
{
    public class TestDatabase : IDisposable
    {
        public MedAppDbContext Context { get; }

        public TestDatabase()
        {
            var options = new OptionsProvider().Get<SqlServerOptions>("sqlserver");
            Context = new MedAppDbContext(new DbContextOptionsBuilder<MedAppDbContext>()
                .UseSqlServer(options.ConnectionString).Options);
        }

        //public TestDatabase()
        //{
        //    var options = new OptionsProvider().Get<PostgresOptions>("postgres");
        //    Context = new MedAppDbContext(new DbContextOptionsBuilder<MedAppDbContext>()
        //        .UseNpgsql(options.ConnectionString).Options);
        //}

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
