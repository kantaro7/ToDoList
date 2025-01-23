using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using Models.InterfaceRepositories;

using System.Reflection;

using ToDoList.Repository.Context;
using ToDoList.Repository.Repositories;
using ToDoList.Service.Contracts;
using ToDoList.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<TDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
//AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Services
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

// Repository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
