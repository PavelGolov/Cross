using Cross.DAL;
using Cross.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cross.BLL.Managers;

namespace Cross.Web
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
            services.AddDbContext<CrossContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("CrossContext"), b => b.MigrationsAssembly("Cross.DAL")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<CrossContext>();

            services.AddControllersWithViews();

            services.AddScoped<CancellationDbEntityManager<Event>>();

            services.AddScoped<RaceManager>();

            services.AddScoped<DbEntityManager<RaceType>>();

            services.AddScoped<DbEntityManager<Venue>>();

            services.AddScoped<DbEntityManager<Discipline>>();

            services.AddScoped<DbEntityManager<RaceStatus>>();

            services.AddScoped<DbEntityManager<Track>>();

            services.AddScoped<ActionManager>();

            services.AddScoped<RequestManager>();

            services.AddScoped<CarManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
