using Business;
using Business.MapperProfiles;
using Business.RabbitMQ.Interfaces;
using Business.RabbitMQ.Producers;
using Data.ContextClasses;
using Data.Dtos.MapperDto;
using Data.EntityClasses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<UserBusiness>();
builder.Services.AddSingleton<IUserProducer, UserProducer>();
//AppDomain.CurrentDomain.GetAssemblies()
builder.Services.AddAutoMapper(c =>
    {
        c.AddProfile<AutoProfile<UserDto, User>>();
        c.AddProfile<AutoProfile<UserDto, User>>();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
