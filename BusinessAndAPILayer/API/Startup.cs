using Business.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete;
using DataAccessLayer.DBContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
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
        {   // Uygulama Aya�a kalk�ncaya kadar olanki k�sm� kullan�r
            // Uygulama Build olupta, aya�a kalk�ncaya kadar gerekli ayarlamalar� yapan yer.
            // Uygulama aya�a kalk�ncaya kadar neyi nereden alaca��n� ne yapaca��n� buradan al�r

            services.AddDbContext<SchoolDbContext>(ServiceLifetime.Transient);  // Her bir DBContext �a�r�ld���nda sistem taraf�ndan newlenecek.
            // �urada DI y� verdik, middleware imizi yazd�k
            services.AddAutoMapper(config=>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddScoped<IDepartmentService, DepartmentServisce>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Uygulama aya�a kalkt�ktan sonraki k�sm� kullan�r.


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
