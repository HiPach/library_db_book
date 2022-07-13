using library_db_book.Controllers.Map;
using Microsoft.OpenApi.Models;

namespace library_db_book
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment env
        )
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy(
                    "AllowAll",
                    policy => {
                        policy
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .AllowCredentials();
                    }
                )
            );
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "library", Version = "v1" });
            });

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "library v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
