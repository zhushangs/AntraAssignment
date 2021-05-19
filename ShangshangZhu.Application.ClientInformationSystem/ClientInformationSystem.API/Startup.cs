using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddScoped<IEmployeesService, EmployeeService>();
            services.AddScoped<IClientsService, ClientService>();
            services.AddScoped<IInteractionsService, InteractionService>();


            services.AddScoped<IEmployeesRepository, EmployeeRepository>();
            services.AddScoped<IClientsRepository, ClientRepository>();
            services.AddScoped<IInteractionsRepository, InteractionRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientInformationSystem.API", Version = "v1" });
            });

            services.AddDbContext<ClientInformationDBContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("ClientInformationSystemDbConnection")
           ));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.Cookie.Name = "ClientInformationSystemAuthCookie";
                option.ExpireTimeSpan = TimeSpan.FromHours(2);
                option.LoginPath = "/Account/login";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientInformationSystem.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader().AllowAnyMethod();
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
