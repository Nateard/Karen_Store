using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Application.Services.Common.FacadePatterns;
using Karen_Store.Application.Services.Finance.FacadePattern;
using Karen_Store.Application.Services.HomePage.FacadePattern;
using Karen_Store.Application.Services.Orders.Commands;
using Karen_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Karen_Store.Application.Services.Orders.Queries.GetUserOrders;
using Karen_Store.Application.Services.PaymentServices.FacadePatterns;
using Karen_Store.Application.Services.Products.FacadePattern;
using Karen_Store.Application.Services.Users.FacadePattern;
using Karen_Store.Common.Role;
using Karen_Store.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using static Karen_Store.Application.Services.Finance.Queries.GetRequestPayForAdmin.IGetRequestPayForAdmin;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    option.AddPolicy(UserRoles.Support, policy => policy.RequireRole(UserRoles.Support));
    option.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
});

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

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<IAddNewOrder, AddNewOrder>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();
#region Facades
// facades
builder.Services.AddScoped<IProductFacade, ProductFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<ICommonFacade, CommonFacade>();
builder.Services.AddScoped<IHomePageFacade, HomePageFacade>();
builder.Services.AddScoped<IFinanceFacade, FinanceFacade>();
builder.Services.AddScoped<IPaymentproviderFacade, PaymentProviderFacade>();
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


app.UseAuthentication();
app.UseAuthorization();


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
