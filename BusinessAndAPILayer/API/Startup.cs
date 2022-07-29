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
        {   // Uygulama Ayaða kalkýncaya kadar olanki kýsmý kullanýr
            // Uygulama Build olupta, ayaða kalkýncaya kadar gerekli ayarlamalarý yapan yer.
            // Uygulama ayaða kalkýncaya kadar neyi nereden alacaðýný ne yapacaðýný buradan alýr

            services.AddDbContext<SchoolDbContext>(ServiceLifetime.Transient);  // Her bir DBContext çaðrýldýðýnda sistem tarafýndan newlenecek.
            // Þurada DI yý verdik, middleware imizi yazdýk
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
            // Uygulama ayaða kalktýktan sonraki kýsmý kullanýr.


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
