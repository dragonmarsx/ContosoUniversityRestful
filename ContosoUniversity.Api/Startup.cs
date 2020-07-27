using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Core.Interfaces;
using ContosoUniversity.Infrastructure.Data;
using ContosoUniversity.Infrastructure.Filters;
using ContosoUniversity.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.Api
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
            services.AddControllers().AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; //#1)         
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<AcademicsDbContext>(options =>            
                options.UseSqlServer(Configuration.GetConnectionString("ContosoUniversity"))
            );
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());        //#2)

            services.AddMvc(option =>
            {
                option.Filters.Add<ValidationFilter>();  //#3)

            })
            .AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());  //#4)
                //options.RegisterValidatorsFromAssemblyContaining(typeof(Infrastructure.Validators.DepartmentDtoValidator));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


/* #1) Part 6 - min23: Avoid circular reference during serialization (nuget required).
 * #2) Part 6 - min42: Obtain assemblies for objects to map (nuget required) 
 * #3) Part 7 - min28: Web Api Configuration and Fluent Validation 
 * #3) Part 7 - min41: Web Api Configuration and Fluent Validation 
 */
