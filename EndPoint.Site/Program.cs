using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Services.Users.Queries.GetRoles;
using Karen_Store.Application.Services.Users.Queries.GetUsers;
using Karen_Store.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
string connectionString = @"Data Source=.; Initial Catalog=Karen_store ; Integrated Security=True;TrustServerCertificate=True;
";
// Add services to the container.
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDatabaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRoleService, GetRoleService>();


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
