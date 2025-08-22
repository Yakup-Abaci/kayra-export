using Microsoft.EntityFrameworkCore;
using Persistence;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices(builder.Configuration["ConnectionStrings:Redis"]);
builder.Services.AddApplicationServices();

// Add services to the container.
builder.Services.AddCors(option => option.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:7022", "http://localhost:5051").
    AllowAnyMethod().AllowAnyHeader()
    ));

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),"logs",autoCreateSqlTable:true)
    .CreateLogger();
builder.Host.UseSerilog(log);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", opt =>
    {
        opt.TokenValidationParameters = new()
        {
            ValidateAudience = true,// olu�turulacak token de�erinin kimlerin kullanaca��n� belirler. izim web sayfas�n�n adresi
            ValidateIssuer = true, //tokeinin kimin da��tt��n� ifade eder. bu api nin adresi
            ValidateLifetime = true, // s�resi
            ValidateIssuerSigningKey = true, // tokenin bize ait olup olamd���n� kontrol eder

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false


        };
    }
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
