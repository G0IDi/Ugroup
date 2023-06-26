global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.SignalR;
using Api.Hubs;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Bcpg;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if RELEASE 
Conexion.SetStringConnection("server=db4free.net;database=ugroup1;user=godooy; password=1025883244; port=3306");
#endif

#if DEBUG 
Conexion.SetStringConnection("server=db4free.net;database=ugroup1;user=godooy; password=1025883244; port=3306");
#endif

//Conexion.SetStringConnection("workstation id = UgroupDataBase.mssql.somee.com; packet size = 4096; user id = godoy_SQLLogin_2; pwd = 9n4ufxwre5; data source = UgroupDataBase.mssql.somee.com; persist security info=False; initial catalog = UgroupDataBase");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapHub<Chat> ("/Chat");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();