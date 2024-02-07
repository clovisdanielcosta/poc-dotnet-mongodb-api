using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Poc.MongoDB.Api.Interfaces;
using Poc.MongoDB.Api.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DbSchoolDatabaseSettings>(builder.Configuration.GetSection(nameof(DbSchoolDatabaseSettings)));
builder.Services.AddSingleton<IDbSchoolDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DbSchoolDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("DbSchoolDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStudentService, IStudentService>();

BsonClassMap.RegisterClassMap<Student>(classMap =>
{
    classMap.MapMember(p => p.Id);
    classMap.MapMember(p => p.Name);
    classMap.MapMember(p => p.IsGraduated);
    classMap.MapMember(p => p.Courses);
    classMap.MapMember(p => p.Gender);
    classMap.MapMember(p => p.Age);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
