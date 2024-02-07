using MongoDB.Bson.Serialization;
using Poc.MongoDB.Api.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


BsonClassMap.RegisterClassMap<Student>(classMap =>
{
    classMap.MapMember(p => p.Id);
    classMap.MapMember(p => p.Name);
    classMap.MapMember(p => p.IsGraduated);
    classMap.MapMember(p => p.Courses);
    classMap.MapMember(p => p.Gender);
    classMap.MapMember(p => p.Age);
});




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
