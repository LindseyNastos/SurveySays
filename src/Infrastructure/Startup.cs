﻿using Infrastructure.Db;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace Infrastructure
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            //var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath).AddJsonFile("../MyAppconfig.json"); // path to your original configuration in Web project

            var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Users\Lindsey\Documents\Visual Studio 2015\Projects\SurveySays\SurveySays\src\SurveySays\appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        }
    }
}