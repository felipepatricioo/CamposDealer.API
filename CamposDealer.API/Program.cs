using AutoMapper;
using CamposDealer.API.Config;
using CamposDealer.API.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var dbConnectionString = builder.Configuration.GetSection(
    "MicrosoftSQlConnection:MicrosoftSQlConnectionString").Value;
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MicrosoftSQLContext>(options =>
options.UseSqlServer(dbConnectionString));

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
