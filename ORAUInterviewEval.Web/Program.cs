using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Core.Models;
using ORAUInterviewEval.Infrastructure.Data;
using ORAUInterviewEval.Infrastructure.Data.Generators;
using ORAUInterviewEval.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));
    options.UseInMemoryDatabase("OrauTasksDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();


//NOTE: Custom service registration
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ICacheService, CacheService>();

builder.Services.AddTransient<DataGenerator, DataGenerator>();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var dataGenerator = scope.ServiceProvider.GetService<DataGenerator>();
    if(dataGenerator != null) dataGenerator.SeedDatabase();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
