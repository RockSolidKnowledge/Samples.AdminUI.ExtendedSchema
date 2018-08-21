using IdentityExpress.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Rsk.Samples.AdminUI.ExtendedSchema
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ExtendedUser, IdentityExpressRole>()
                .AddEntityFrameworkStores<ExtendedDbContext>();

            //Server=.\\SQLEXPRESS;integrated Security=true;Database=IdentitySecurityTest;
            services.AddDbContext<ExtendedDbContext>(db => db.UseSqlServer("Server=.\\SQLEXPRESS;integrated Security=true;Database=IdentitySecurityTest;"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
        }
    }
}
