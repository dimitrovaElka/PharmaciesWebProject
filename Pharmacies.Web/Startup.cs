using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharmacies.Data;
using Pharmacies.Models;
using Pharmacies.Web.Models.AccountViewModels;
using Pharmacies.Web.Services;
using Pharmacies.Web.Services.Contracts;
using Pharmacies.Web.Utilities;
using System;

namespace Pharmacies.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            });

            services.AddDbContext<PharmaciesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<PharmaciesUser, IdentityRole>(identityOption =>
            {
                identityOption.Password.RequiredLength = 3;
                identityOption.Password.RequireDigit = false;
                identityOption.Password.RequireUppercase = false;
                identityOption.Password.RequireLowercase = false;
                identityOption.Password.RequiredUniqueChars = 0;
                identityOption.Password.RequireNonAlphanumeric = false;
            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<PharmaciesDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IPharmaciesService, PharmaciesService>();
            services.AddTransient<IAccountsService, AccountsService>();

            services.AddAutoMapper(config =>
            {
                config.CreateMap<RegisterViewModel, PharmaciesUser>();
            });

            services.AddMvc(opt =>
            {
                opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider, PharmaciesDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            Seeder.SeedRoleAsync(provider).Wait();

            Seeder.SeedCities(dbContext).Wait();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "areas",
            template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
