using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess.Interface;
using BusinessLogic;
using BusinessLogic.Interface;
using DataAccess;
using Domain;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi
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
            var server = Configuration["Server"] ?? "127.0.0.1";
            var port = Configuration["DBPort"] ?? "3306";
            var user = Configuration["DBUser"] ?? "root";
            var password = Configuration["DBPassword"] ?? "root";
            var database = Configuration["Database"] ?? "Simplified";

            services.AddControllers();
            //services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<DbContext,Context>(options => 
                options.UseMySQL($"server={server},{port};database={database};user={user};password={password};")
            );

            // DataAccess interfaces
            //services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();

            // BusinessLogic interfaces
            services.AddScoped<ICourseLogic, CourseLogic>();
            services.AddScoped<ISectionLogic, SectionLogic>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddCors(
                options =>
                {
                    options.AddPolicy(
            "CorsPolicy",
            builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
                );
                }
            );
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
