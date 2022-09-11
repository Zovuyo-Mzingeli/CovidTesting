using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Corona.Data;
using Corona.Models;
using Corona.Models.Repositories.BookingRepositories;
using Corona.Models.Repositories.ProfileImage;
using Corona.Services;
using ReflectionIT.Mvc.Paging;
using Corona.Models.Repositories.DependentRepository;
using Corona.Models.Repositories.FavouriteSuburbs;
using Corona.Models.Repositories.FavourateSuburbs;

namespace Corona
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
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Account/Login";
                 });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => 
            {
                options.Stores.MaxLengthForKeys = 128;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CoronaContext>().AddDefaultTokenProviders();

            services.AddDbContext<CoronaContext>(options =>
            options.UseSqlServer(Configuration["Data:ConnectionString:CoronaDB"]));
            //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();

           
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            //services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IDependentRepository, DependentRepository>();
            services.AddTransient<IFavouriteSuburbRepository, FavouriteSuburbRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddPaging();

            services.AddAutoMapper();
            services.AddControllersWithViews();
            services.AddMvc().AddXmlSerializerFormatters();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(20);
                opts.Cookie.HttpOnly = true;
            });
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(VisitorCounterMiddleware));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                ///endpoints.MapRazorPages();
            });
            //await RoleConfiguration.Initial(roleManager);
        }
    }
}
