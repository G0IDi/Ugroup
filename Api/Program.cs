using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Conexion.SetStringConnection("server=localhost;database=example;user=root; password=; port=3306");



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();