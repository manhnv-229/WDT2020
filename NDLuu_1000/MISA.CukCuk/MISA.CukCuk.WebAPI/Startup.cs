using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.BL;
using MISA.BL.Interfaces;
using MISA.DAO;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI
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

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.WebAPI", Version = "v1" });
            });
            //Customer
            services.AddScoped<ICustomerDAO, CustomerDAO>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            //Employee
            services.AddScoped<IEmployeeDAO, EmployeeDAO>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();
            //Department
            services.AddScoped<IDepartmentDAO, DepartmentDAO>();
            services.AddScoped<IDepartmentBL, DepartmentBL>();
            //Position
            services.AddScoped<IPositionDAO, PositionDAO>();
            services.AddScoped<IPositionBL, PositionBL>();
            //WorkStatus
            services.AddScoped<IWorkStatusDAO, WorkStatusDAO>();
            services.AddScoped<IWorkStatusBL, WorkStatusBL>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.WebAPI v1"));
            
            }

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
