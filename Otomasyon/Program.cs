using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Otomasyon.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = false;
});

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});


builder.Services.AddSession();


builder.Services.AddAuthentication(
              CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
              x =>
              {
                  x.Cookie.Name = "CustomCookie";
                  x.Cookie.HttpOnly = true;
                  x.Cookie.SameSite = SameSiteMode.Strict;
                  x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                  x.ExpireTimeSpan = TimeSpan.FromDays(5);
                  x.LoginPath = "/login/index/";
              });

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//        options.SlidingExpiration = true;
//        options.AccessDeniedPath = "/Forbidden/";
//        options.LoginPath = "/login/index/";
//    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();
//app.MapDefaultControllerRoute();

app.Run();
