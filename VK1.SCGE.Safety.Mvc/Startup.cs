using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using VK1.SCGE.Safety.Mvc.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VK1.SCGE.Safety.Services.Data;
using VK1.SCGE.Safety.Services;
using VK1.SCGE.Safety.Mvc.Services;
using Rotativa.AspNetCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace VK1.SCGE.Safety.Mvc {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AppDb")));

            services.AddDbContext<AppDb>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("AppDb"))
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging());

            services.AddDbContext<AppQueryDb>(options =>
               options
               .UseSqlServer(Configuration.GetConnectionString("AppDb"))
               .EnableSensitiveDataLogging());

            services.AddDbContext<OnebookQueryDb>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("OnebookQueryDb"))
                .EnableSensitiveDataLogging());

            //Used MySql(Oracle)
            services.AddDbContext<MySqlQueryDb>(options => options
            // replace with your connection string
            .UseMySql(Configuration.GetConnectionString("MySqlDev"), mySqlOptions => mySqlOptions
            // replace with your Server Version and Type
            .ServerVersion(new Version(8, 0, 18), ServerType.MySql)));


            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
               // .AddDefaultUI(UIFramework.Bootstrap4)
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.AddCors(options => options.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ILog, LineNotify>();

            services.AddScoped<App>();
            services.AddScoped<AppQuery>();
            services.AddScoped<OnebookQuery>();
            services.AddScoped<Util>();
            services.AddScoped<MySqlQuery>();

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env, "rotativa");
        }
    }
}
