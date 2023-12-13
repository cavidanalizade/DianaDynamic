using DianaDynamic.DAL;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBC>(options => options.UseSqlServer("server=DESKTOP-HD09TL8; database=DianaDynamic; Trusted_connection=true; Integrated security=true; Encrypt=false"));
var app = builder.Build();



app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
