using library_db_book.Controllers.Map;
using Microsoft.OpenApi.Models;
namespace library_db_book
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });
        }
    }
}
