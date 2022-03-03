using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using SelfieAWookies.Core.Selfies.Infrastructures.Repository;
using SelfieAWookie.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SelfiesContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), sqlServerOption => 
    {
    
    });
   });
builder.Services.AddInjections();
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
