using BAL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Database;
using BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // This step is optional, for generating Swagger JSON and UI.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

