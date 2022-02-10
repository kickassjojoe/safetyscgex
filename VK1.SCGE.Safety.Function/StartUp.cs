using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Configuration;
using VK1.SCGE.Safety.Services;
using VK1.SCGE.Safety.Services.Data;


[assembly: FunctionsStartup(typeof(VK1.SCGE.Safety.Function.Startup))]
namespace VK1.SCGE.Safety.Function {
    public class Startup : FunctionsStartup {

        public override void Configure(IFunctionsHostBuilder builder) {

            builder.Services.AddDbContext<FunctionDb>(options =>
                 options
                 .UseSqlServer(Environment.GetEnvironmentVariable("FunctionDb"))
                 .UseLazyLoadingProxies()
                 .EnableSensitiveDataLogging()
                 );

            //Used MySql(Oracle)
            builder.Services.AddDbContext<MySqlQueryDb>(options => options
            // replace with your connection string
            .UseMySql(Environment.GetEnvironmentVariable("MySqlDev"), mySqlOptions => mySqlOptions
            // replace with your Server Version and Type
            .ServerVersion(new Version(8, 0, 18), ServerType.MySql)));

            builder.Services.AddDbContext<AppDb>(options =>
                options
                .UseSqlServer(Environment.GetEnvironmentVariable("AppDb"))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging());

            //
            builder.Services.AddScoped<Util>();
            builder.Services.AddTransient<ILog, LineNotify>();
            builder.Services.AddScoped<MySqlQuery>();
            builder.Services.AddScoped<App>();

        }
    }
}
