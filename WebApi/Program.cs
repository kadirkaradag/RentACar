using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

//builder.Services.AddDistributedMemoryCache(); //inMemory cache

//redis icin microsoft un StackExchangeRedis paketini kurduk webApi projesine
//docker � baslatt�m, cmd ye; docker run --name narch-redis -p 6379:6379 -d redis
//yazd�k redis i kurdu, sonra redis insigth tool unu indirdik sitesinden. o kendi docker �n redisini g�rd� ve projeyi cal�st�r�p request att�g�m�zda  redis insigth �zerinde requesti g�rd�k.
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");  

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

//if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
