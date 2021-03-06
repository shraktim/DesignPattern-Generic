﻿using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern_Generic.BLL.Contracts;
using DesignPattern_Generic.BLL.Manager;
using DesignPattern_Generic.DbContext.ApplicationDbContext;
using DesignPattern_Generic.Repositories.Contracts;
using DesignPattern_Generic.Repositories.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPattern_Generic.AppConfiguration.AppConfiguration
{
   public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"),
                b=>b.MigrationsAssembly("DesignPattern-Generic.DbContext")));


            services.AddTransient<IEntityModelRepository, EntityModelRepository>();
            services.AddTransient<IEntityModelManager, EntityModelManager>();
            services.AddTransient<IDemoModelRepository, DemoModelRepository>();
            services.AddTransient<IDemoModelManager, DemoModelManager>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
