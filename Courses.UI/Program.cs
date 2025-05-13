using Courses.BL.Services;
using Courses.DAL;
using Courses.DAL.Data;
using Courses.DAL.Repositories;
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

webAppBuilder.Services.AddScoped<ICourseRepository, CourseRepository>();
webAppBuilder.Services.AddScoped<IStudentsGroupRepository, StudentsGroupRepository>();
webAppBuilder.Services.AddScoped<IStudentRepository, StudentRepository>();

webAppBuilder.Services.AddScoped<ICourseService, CourseService>();
webAppBuilder.Services.AddScoped<IStudentsGroupService, StudentsGroupService>();
webAppBuilder.Services.AddScoped<IStudentService, StudentService>();

var connectionString = webAppBuilder.Configuration.GetConnectionString("DefaultConnection");
Log.Logger.Information($"Using connection: {connectionString}");
var app = webAppBuilder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "student",
    pattern: "Student/{action=Details}/{id?}",
    defaults: new { controller = "Student" });

app.MapControllerRoute(
    name: "group",
    pattern: "Group/{action=Edit}/{id?}",
    defaults: new { controller = "Group" });

app.MapControllerRoute(
    name: "courses",
    pattern: "Courses/{action=Index}/{id?}",
    defaults: new { controller = "Courses" });

app.MapFallback(context =>
{
    context.Response.Redirect("/Courses");
    return Task.CompletedTask;
});

app.Run();
