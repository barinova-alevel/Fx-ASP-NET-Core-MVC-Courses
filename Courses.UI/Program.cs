using Courses.DAL;
using Courses.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configurationBuilder)
            .CreateLogger();
Log.Logger.Information("start");

var webAppBuilder = WebApplication.CreateBuilder(args);
webAppBuilder.Services.AddControllersWithViews();

webAppBuilder.Services.AddDbContext<CoursesDbContext>(options =>
options.UseSqlServer(webAppBuilder.Configuration.GetConnectionString("DefaultConnection")));

var connectionString = webAppBuilder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Using connection: {connectionString}");

var app = webAppBuilder.Build();

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
    pattern: "{controller=Courses}/{action=Index}/{id?}");

app.Run();
