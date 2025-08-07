using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ECARTemplate.Data;
using ECARTemplate.Models;
using ECARTemplate.Extensions;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Threading.Tasks; // Add this for Task.CompletedTask

namespace ECARTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SmartSettings>(Configuration.GetSection(SmartSettings.SectionName));
            services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication("Custom")
                .AddCookie("Custom", options =>
                {
                    options.LoginPath = "/Page/Login"; // Ruta a tu página de inicio de sesión
                    options.LogoutPath = "/Page/Logout"; // Ruta para cerrar sesión
                    // --- REMOVED: options.AccessDeniedPath = "/Home/AccesoDenegado"; ---
                    // Eliminamos esta línea para que no redirija a una página específica.

                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Duración de la cookie de sesión
                    options.SlidingExpiration = true; // Renueva la cookie si el usuario está activo

                    // --- ADDED: Custom handling for Access Denied ---
                    options.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden; // Set HTTP status code to 403 Forbidden
                        context.Response.ContentType = "text/html; charset=utf-8";
                        string script = "<script>alert('¡No autorizado!'); window.location.href = '/';</script>";
                        return context.Response.WriteAsync(script);
                    };
                    // --- END ADDED ---
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireUserRole", policy => policy.RequireRole("Estandar"));
            });

            services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                    pattern: "{controller=Page}/{action=Login}");

                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{controller=Admin}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "empleados",
                    pattern: "{controller=Empleados}/{action=Details}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}