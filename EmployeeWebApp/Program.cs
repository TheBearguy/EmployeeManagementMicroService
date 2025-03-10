//using BAL.Interfaces;
//using DAL.Interfaces;
//using DAL.Repositories;
//using DAL.Database;
//using BAL.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//    builder.Services.AddSingleton<IDatabaseHelper, DatabaseHelper>();
//    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//    builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//    builder.Services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();

//    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//    builder.Services.AddScoped<IProjectService, ProjectService>();
//    builder.Services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();

//    builder.Services.AddControllersWithViews();

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();  // This step is optional, for generating Swagger JSON and UI.

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseRouting();
//app.UseAuthorization();
//app.MapControllers();
//app.UseHttpsRedirection();
//app.Run();

using BAL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Database;
using BAL.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Register DatabaseSettings configuration
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// Register services with connection string injection
builder.Services.AddSingleton<IDatabaseHelper, DatabaseHelper>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>();
    return new DatabaseHelper(settings);
});

builder.Services.AddScoped<IEmployeeRepository>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>();
    return new EmployeeRepository(settings);
});

builder.Services.AddScoped<IProjectRepository>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>();
    return new ProjectRepository(settings);
});

builder.Services.AddScoped<IEmployeeProjectRepository>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>();
    return new EmployeeProjectRepository(settings);
});

// Register services that don't require a connection string
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();

// Add framework services
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();


