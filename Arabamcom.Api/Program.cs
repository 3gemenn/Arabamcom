using Arabamcom.Core.Services;
using Arabamcom.Repository.DbContext;
using Arabamcom.Service.Services;
using Microsoft.AspNetCore.Connections;
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ConnectionHelper>();
builder.Services.AddScoped<IAdvertService, AdvertService>();
builder.Services.AddScoped<IAdvertVisitService, AdvertVisitService>();
builder.Services.AddHttpContextAccessor();
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
