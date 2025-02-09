using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Common.FacadePatterns;
using Karen_Store.Application.Services.Products.FacadPatern;
using Karen_Store.Application.Services.Users.FacadePattern;
using Karen_Store.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
//using FluentValidation;
//using FluentValidation.AspNetCore;

//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(config =>
//    {
//        // Automatic registration of all validators in the assembly
//        config.RegisterValidatorsFromAssemblyContaining<RequestRegisterUserValidator>();
//    });

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.AccessDeniedPath = new PathString("/Authentication/Signin");
});


string connectionString = @"Data Source=.; Initial Catalog=Karen_store ; Integrated Security=True;TrustServerCertificate=True;
";
// Add services to the container.
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDatabaseContext, DataBaseContext>();


#region Facades
// facades
builder.Services.AddScoped<IProductFacade, ProductFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<ICommonFacade, CommonFacade>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapStaticAssets();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
