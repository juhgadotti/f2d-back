using Food2Desk.Core;
using Food2Desk.Core.Order;
using Food2Desk.Shared.Interfaces;
using Food2Desk.DataAccess;
using Food2Desk.DataAccess.Product;
using Food2Desk.DataAccess.Order;
using Food2Desk.DataAccess.Lunch;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces.Lunch;
using Food2Desk.Core.Lunch;
using Food2Desk.Core.Base;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddScoped<IProductCore, Product>();
builder.Services.AddScoped<IProductDataAccess, ProductDataAccess>();
builder.Services.AddScoped<IOrderDataAccess, OrderDataAccess>();
builder.Services.AddScoped<IOrderCore, Order>();
builder.Services.AddScoped<ILunchDataAccess, LunchDataAccess>();
builder.Services.AddScoped<ILunchCore, Lunch>();
builder.Services.AddScoped<IUserCore, User>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();
builder.Services.AddScoped<IOfficeDataAccess, OfficeDataAccess>();
builder.Services.AddScoped<IUserAuthDataAccess, UserAuthDataAccess>();

ContextConfig.CreateContexts(builder.Configuration, builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
