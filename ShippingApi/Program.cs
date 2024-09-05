using DataAccess;
using DataAccess.Abstract;
using DataAccess.Implements;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var nameApp = builder.Configuration.GetSection("NameApp").Value;
var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnetion");



// Add minimal services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IUrlHelper>(factory =>
{
    var actionContext = factory.GetRequiredService<IActionContextAccessor>().ActionContext!;
    return new UrlHelper(actionContext);
});

//Add repository
builder.Services.AddScoped<ITipoPaqueteRepository, TipoPaqueteRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});


// Add services.
builder.Services.AddScoped<DapperContext>();
builder.Services.Configure<DbConnectionOptions>(options =>
{
    options.ConnectionString = defaultConnection;
    options.CommandTimeout = 120;
});

// Add services to the container.





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
