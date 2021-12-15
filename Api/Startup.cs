using Application.PipilineBehavior;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.BaseContext;
using Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<SiemensContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("SiemensSQL")));

            services.AddDbContext<SiemensContext>(opt => opt.UseInMemoryDatabase("SiemensSQL"));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

            });

            var assembly = AppDomain.CurrentDomain.Load("Application");
            AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(result =>
                {
                    services.AddScoped(result.InterfaceType, result.ValidatorType);
                });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);

            services.AddAutoMapper(assembly);

            #region Repositories

            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IClientRepository, ClientRepository>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}