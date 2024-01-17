using System.Net;
using App.Models;
using App.Services;
using AppExtendMedthods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>( options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppMvcConnectionString"));
});

builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>( options => {
    //View/Controller/Action.cshtml
    //Myview/Controller/Action.cshtml


    // {0} Name Action
    // {1} Name Controller
    // {2} Name Area
    options.ViewLocationFormats.Add("/Myview/{1}/{0}" + RazorViewEngine.ViewExtension );
}
);

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<PlanetService>();


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
// app.AddStatusCodePage();    // Phương thức mở rộng tùy biến response 400 - 599



app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();


// Tùy biên map
app.AddMyEndPoint();
app.MapControllerRoute(
    name: "first" ,
    pattern: "/xemsanpham/{id}",
    defaults: new {
        controller = "First",
        action = "ViewProduct",
        id = 2
    }
    // constraints: new {
    //     id = new RangeRouteConstraint(1 , 4)
    // }
 );

app.MapAreaControllerRoute( 
    name: "product",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName: "ProductManage"
);
app.MapAreaControllerRoute( 
    name: "DbManage",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName: "Database"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
