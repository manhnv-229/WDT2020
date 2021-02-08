using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Misa.BL;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Result;
using Misa.BL.ServiceImp;
using Misa.BL.Properties;
using Misa.DL;
using Misa.DL.CustomerRepository;
using Misa.DL.EmployeeRepository;
using Newtonsoft.Json.Serialization;

namespace Misa.CukCuk_3
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
            //add scope Base Repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            //add scope Customer Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();

            //add scope Customer Service
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();

            //add scope Repository Employee
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();

            //add scope Service Employee
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeePositionService, EmployeePositionService>();
            services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();


            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Misa.CukCuk_3", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Misa.CukCuk_3 v1"));
            }

            //app.UseExceptionHandler(a => a.Run(async context =>
            //{
            //    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //    var exception = exceptionHandlerPathFeature.Error;

            //    var serviceResult = new ServiceResult();
            //    serviceResult.Messenger.Add(Resources.Exception_User_Mess);

            //    await context.Response.WriteAsJsonAsync(serviceResult);
            //}));

            app.UseRouting();

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
