using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using AspNetCoreRateLimit;
using DinoApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers(options => 
// {
//     options.RespectBrowserAcceptHeader = true;
//     options.ReturnHttpNotAcceptable = true;
// }).AddXmlSerializerFormatters();

builder.Services.AddControllers()
.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureApiVersioning();
builder.Services.JwtConfiguration(builder.Configuration);

builder.Services.AddDbContext<MainContext>(options => {
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
