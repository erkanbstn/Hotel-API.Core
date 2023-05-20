using ApiConsume.DataAccessLayer.Concrete;
using ApiConsume.EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Frontend_Mvc.Core.ValidationRules;
using Frontend_Mvc.Core.ViewModels.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddTransient<IValidator<RoomViewModel>, RoomValidationRules>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context>().AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddMvc(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    opt.LoginPath = "/Auth/Login/";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Main/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();
