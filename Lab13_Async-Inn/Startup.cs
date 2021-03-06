﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Interfaces;
using Lab13_AsyncInn.Models.Services;
using System.IO;

namespace Lab13_AsyncInn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProdConn"]));
            services.AddTransient<IAmenities, AmenitiesService>();
            services.AddTransient<IHotel, HotelService>();
            services.AddTransient<IRoom, RoomService>();
            services.AddTransient<ILayout, LayoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(route =>
            {
                route.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
        }
    }
}
