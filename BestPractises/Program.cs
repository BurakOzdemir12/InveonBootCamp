using BestPractises.Interfaces;
using BestPractises.Repositories;
using BestPractises.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();

IConfiguration configuration = builder.Configuration;
var redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<ILibraryService, LibraryServices>();

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
