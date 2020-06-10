using System;
using CodebitsAcademyEFC.Areas.Identity.Data;
using CodebitsAcademyEFC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CodebitsAcademyEFC.Areas.Identity.IdentityHostingStartup))]
namespace CodebitsAcademyEFC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthCodebitsAcademyEFCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthCodebitsAcademyEFCContextConnection")));

                services.AddDefaultIdentity<ApplicationUsers>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuthCodebitsAcademyEFCContext>();
            });
        }
    }
}