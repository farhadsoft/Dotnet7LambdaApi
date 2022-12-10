using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repostories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//var cs = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));
builder.Services.AddScoped<IPersonRepostory, PersonRedisRepo>();

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapGet("/api/Person/{id}", (IPersonRepostory personRepo, string id) =>
{
    var result = personRepo.GetPersonById(id);
    return result;
})
.WithName("GetPersonById")
.WithOpenApi();

app.MapPost("/api/Person", (IPersonRepostory personRepo, Person person) =>
{
    personRepo.CreatePerson(person);
})
.WithName("CreatePerson")
.WithOpenApi();

app.MapGet("/api/Persons", (IPersonRepostory personRepo) =>
{
    var result = personRepo.GetPersons();
    return result;
})
.WithName("GetAllPersons")
.WithOpenApi();

app.Run();