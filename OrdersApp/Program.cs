using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrdersApp.Models;
using OrdersApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OrdersStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(OrdersStoreDatabaseSettings)));

builder.Services.AddSingleton<IOrdersStoreDatabaseSettings>(sp => 
    sp.GetRequiredService<IOptions<OrdersStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("OrdersStoreDatabaseSettings:ConnectionString")));

builder.Services.AddCors();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors(options => {
    options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run("http://localhost:5115");