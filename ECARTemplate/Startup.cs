

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
using Microsoft.AspNetCore.Identity;
using System; // Asegúrate de tener este using

namespace ECARTemplate
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
            services.Configure<SmartSettings>(Configuration.GetSection(SmartSettings.SectionName));

            // Note: This line is for demonstration purposes only, I would not recommend using this as a shorthand approach for accessing settings
            // While having to type '.Value' everywhere is driving me nuts (>_<), using this method means reloaded appSettings.json from disk will not work
            services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication("Custom") // Cambia el esquema de autenticación por defecto
                .AddCookie("Custom", options =>
                {
                    options.LoginPath = "/Page/Login"; // Ruta a tu página de inicio de sesión
                    options.LogoutPath = "/Page/Logout"; // Ruta para cerrar sesión (necesitarás crear esta acción)
                    options.AccessDeniedPath = "/Home/AccesoDenegado"; // Ruta para acceso denegado (opcional)
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Duración de la cookie de sesión
                    options.SlidingExpiration = true; // Renueva la cookie si el usuario está activo
                });
            //.AddNegotiate(); // Mantén la autenticación Negotiate si la necesitas

            // services.AddAuthorization(options =>
            // {
            //     // By default, all incoming requests will be authorized according to the default policy.
            //     options.FallbackPolicy = options.DefaultPolicy;
            // });

            services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();

            // services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            //  .AddRoleManager<RoleManager<IdentityRole>>()
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                    pattern: "{controller=Page}/{action=Login}"); // Ruta predeterminada para el inicio

                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{controller=Admin}/{action=Index}/{id?}"); // Ruta para el AdminController

                endpoints.MapRazorPages();
            });
        }
    }
}