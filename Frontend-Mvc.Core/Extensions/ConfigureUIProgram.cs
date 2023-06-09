using ApiConsume.DataAccessLayer.Concrete;
using ApiConsume.EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Frontend_Mvc.Core.ValidationRules;
using Frontend_Mvc.Core.ViewModels.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Frontend_Mvc.Core.Extensions
{
    public static class ConfigureUIProgram
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllersWithViews().AddFluentValidation();
            services.AddDbContext<Context>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Sql"));
            });
            services.AddTransient<IValidator<RoomViewModel>, RoomValidationRules>();
            services.AddHttpClient();
            services.AddDbContext<Context>().AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.LoginPath = "/Auth/Login/";
            });
        }
        public static WebApplication ConfigureApp(this WebApplication webApplication)
        {
            // Configure the HTTP request pipeline.
            if (!webApplication.Environment.IsDevelopment())
            {
                webApplication.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                webApplication.UseHsts();
            }

            webApplication.UseStatusCodePagesWithReExecute("/Main/Error404", "?code={0}");
            webApplication.UseHttpsRedirection();
            webApplication.UseStaticFiles();
            webApplication.UseAuthentication();
            webApplication.UseRouting();

            webApplication.UseAuthorization();

            webApplication.MapControllerRoute(
                name: "default",
                pattern: "{controller=Main}/{action=Index}/{id?}");

            webApplication.Run();
            return webApplication;
        }
    }
}
