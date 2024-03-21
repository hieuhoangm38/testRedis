


using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using test.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IConnectionMultiplexer>
//    (ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
//builder.Services.AddDistributedRedisCache(option =>
//{
//    //option.Configuration = this.Configuration.GetSection("RedisConnectionSettings")["ConnectionString"];
//    //option.InstanceName = this.Configuration.GetSection("RedisConnectionSettings")["InstanceName"];
//});
builder.Services.AddScoped<ITestService, TestService>();

//builder.Services.addD

//builder.Services.AddStackExchangeRedisExtensions((options) =>
//{
//    options
//});

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:RedisCache");
//});
//builder.Services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());


//builder.Services.AddSingleton < IConnectionMultiplexer(ConnectionMultiplexer
//    .Connect("localhost:6379,allowAdmin=true"));

//builder.Services.AddScoped<ICacheClient, CacheClient>();

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
