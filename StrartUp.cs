using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReverseEnginereeing.Data;

namespace ReverseEnginereeing
{
    public class StrartUp
    {
        private IConfiguration _config;

        public StrartUp(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //services.AddDbContext<NadlanDbContext>(opt => opt.UseSqlServer());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
