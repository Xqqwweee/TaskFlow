using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TaskFlow.Data;
using TaskFlow.Interfaces.Repositories;
using TaskFlow.Interfaces.Services;
using TaskFlow.Repositories;
using TaskFlow.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TaskFlowDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
        );
});

//Service
builder.Services.AddScoped<IProjectService, ProjectService>();
//Repository
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
