using Clippy.AuthenticationProviders;
using Clippy.Data;
using Clippy.Models.Admin;
using Clippy.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;

namespace Clippy
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
            if (String.IsNullOrEmpty(Configuration["GitHub:ClientId"]) ||
                String.IsNullOrEmpty(Configuration["GitHub:ClientSecret"]))
            {
                string errorMessage = "Your GitHub OAuth application details were not found. Please add values for the following entries in your app's configuration: \"GitHub:ClientId\", \"GitHub:ClientSecret\"\nTo do this using app secrets, follow the instructions here: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets#set-a-secret";
                Environment.FailFast(errorMessage);
            }

            var adminSettings = Configuration.GetSection("Admin");
            services.Configure<AdminSettings>(adminSettings);

            services.AddControllersWithViews();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Settings");
                options.Conventions.AuthorizeFolder("/Bookmarks");
                options.Conventions.AuthorizeFolder("/Following");
                options.Conventions.AuthorizeFolder("/Notifications");

                var secureByAdminRole = adminSettings.GetValue<bool>("SecureByAdminRole");
                if (secureByAdminRole)
                    options.Conventions.AuthorizeFolder("/Admin", "AdminRoleOnly");
                else
                    options.Conventions.AuthorizeFolder("/Admin");
            }).AddRazorRuntimeCompilation();

            services.AddDbContext<ClippyContext>(options => options.UseSqlite("Data Source=clippy.db"));

            services.AddScoped<IClaimsTransformation, AddRolesClaimsTransformation>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "GitHub";
            })
            .AddCookie()
            .AddGitHubAuthentication(Configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRoleOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            });
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
                app.UseDeveloperExceptionPage();
                // app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("~/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
