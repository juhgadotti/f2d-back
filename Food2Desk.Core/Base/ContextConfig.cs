using Food2Desk.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace Food2Desk.Core.Base
{
    public class ContextConfig
    {
        public static void CreateContexts(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<Food2deskContext>((serviceProvider, options) =>
            {                
                var sscsb = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"))
                {
                    ApplicationName = "Food 2 Desk"
                };

                options
                .LogTo(Console.WriteLine)
                .UseNpgsql(sscsb.ConnectionString)
                .EnableSensitiveDataLogging();
            });

            services.AddDbContext<Food2deskContext>((serviceProvider, options) =>
            {
                var sscsb = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"))
                {
                    ApplicationName = "Food 2 Desk"
                };

                options
                .LogTo(Console.WriteLine)
                .UseNpgsql(sscsb.ConnectionString)
                .EnableSensitiveDataLogging();
            });

            services.AddScoped<IDbConnection>((a) =>
            {                
                var sscsb = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"))
                {
                    ApplicationName = "Food 2 Desk"
                };
                var connection = new NpgsqlConnection(sscsb.ConnectionString);
                connection.Open();
                return connection;
            });
        }
    }
}
