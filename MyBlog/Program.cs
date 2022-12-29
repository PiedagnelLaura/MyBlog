global using MyBlog.ViewModels;
using Microsoft.EntityFrameworkCore;
using MyBlog.Repository.Context;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data;
using MyBlog.Repository.DAL;
using Microsoft.AspNetCore.Identity;
using MyBlog.Models;

var builder = WebApplication.CreateBuilder(args);



//Add Entity Framework 
builder.Services.AddDbContext<DbBlogContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbContext")));

builder.Services.AddDefaultIdentity<MyBlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DbBlogContext>();

builder.Services.AddTransient<ArticlesPublicDAL>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var mvcBuilder = builder.Services.AddRazorPages();
//builder.Services.AddDbContext<MyBlogContext>(options =>
   // options.UseSqlServer(builder.Configuration.GetConnectionString("MyBlogContext") ?? throw new InvalidOperationException("Connection string 'MyBlogContext' not found.")));

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<DbBlogContext>();
//    context.Database.EnsureCreated();
//    // DbInitializer.Initialize(context);
//}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
