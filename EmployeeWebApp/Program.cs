using BAL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Database;
using BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDatabaseHelper, DatabaseHelper>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IProjectRepository, ProjectRepository>();
    services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();

    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IProjectService, ProjectService>();
    services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();

    services.AddControllersWithViews();
}
