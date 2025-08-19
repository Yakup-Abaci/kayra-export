using KayraExportAPI.Context;
using KayraExportAPI.Contretes.ProductContretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(option => option.AddDefaultPolicy(
    policy => policy.WithOrigins("http://localhost:7022", "http://localhost:5051").
    AllowAnyMethod().AllowAnyHeader()
    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KayraExportDbContext>(opt => opt.UseSqlServer(builder.Configuration["ConnectionStrings:sqlConnection"]));
builder.Services.AddScoped<ProductWriteConcretes>();
builder.Services.AddScoped<ProductReadConcretes>();
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
