using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Configurations;
using OrganizadorPOs.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.RegisterDependencies();

string? connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.ConfigAutoMapper();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
