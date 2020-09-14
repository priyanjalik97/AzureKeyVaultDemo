using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Data;

namespace ProductManagementWebApi
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

            string conn = Configuration.GetConnectionString("ProductManagementDB");
            services.AddDbContext<ProductManagementContext>(opt => opt.UseSqlServer(conn));

            //YR: To use interface of repo
            services.AddScoped<IProductManagementRepo, ProductManagementRepo>();

            services.AddControllers();

            services.AddSwaggerGen(swagger =>
           {
               swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                  new Microsoft.OpenApi.Models.OpenApiInfo
                                  {
                                      Title = SwaggerConfiguration.DocInfoTitle,
                                      Version = SwaggerConfiguration.DocInfoVersion,
                                      Description = SwaggerConfiguration.DocInfoDescription,
                                      Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = SwaggerConfiguration.ContactName, Url = new System.Uri(SwaggerConfiguration.ContactUrl) }
                                  });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

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
