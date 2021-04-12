using AutoMapper;
using AccountDemo.Models.Persistence;
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
using AccountDemo.Services;
using AccountDemo.Services.Impl;
using AccountDemo.Repositories;
using AccountDemo.Repositories.Impl;
using System.Xml.XPath;
using System.IO;

namespace AccountDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string allowSpecificOrigins = "_allowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration.GetConnectionString("Database");

            services.AddDbContext<AccountContext>(options => options.UseSqlite(connectionString));

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountDemo", Version = "v1" });
                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: allowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("localhost").AllowAnyMethod();
                                  });
            });

            services.AddControllers();
            services.AddHealthChecks();
            services.AddSingleton(this.Configuration);

            this.RegisterDependencyInjection(services);
        }

        private static string GetXmlCommentsPath()
        {
            var xmlFile = "AccountDemo.xml";
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlFile);
            
            return xmlPath;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AccountContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountDemo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(allowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            _ = context.Database.EnsureCreated();
        }

        private void RegisterDependencyInjection(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            services.AddHttpContextAccessor();

            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();

        }
    }
}
