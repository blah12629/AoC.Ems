using Aoc.Ems.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aoc.Ems.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        IHostingEnvironment _environment;

        public Startup(IConfiguration configuration, IHostingEnvironment environment) 
        {
             Configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<EmsDbContext>(options =>
            {
                if(_environment.IsDevelopment()) 
                    options.UseSqlite(Configuration.GetConnectionString("EmsDb"));
                else options.UseSqlServer(Configuration.GetConnectionString("EmsDb"));
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EmsDbContext emsDbContext)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            emsDbContext.Initialize();
        }
    }
}
