using library_db_book.Controllers.Map;

namespace library_db_book
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
        }
    }
}
