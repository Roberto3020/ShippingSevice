using BusinessLogic.Abstract;
using BusinessLogic.Implements;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Implements;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using ShippingApi.Helpers.ApiGeneral;
using ShippingApi.Infrastructure.AutoMapper.Profiles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var nameApp = builder.Configuration.GetSection("NameApp").Value;
var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add minimal services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

// Add essential services for MVC and HttpContext
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IUrlHelper>(factory =>
{
    var actionContext = factory.GetRequiredService<IActionContextAccessor>().ActionContext!;
    return new UrlHelper(actionContext);
});

builder.Services.AddScoped<DapperContext>();
builder.Services.Configure<DbConnectionOptions>(options =>
{
    options.ConnectionString = defaultConnection;
    options.CommandTimeout = 120;
});

// Add Service
builder.Services.AddScoped<ITipoPaqueteService, TipoPaqueteService>();
builder.Services.AddScoped<IRemitenteService, RemitenteService>();

// Add repository
builder.Services.AddScoped<ITipoPaqueteRepository, TipoPaqueteRepository>();
builder.Services.AddScoped<IPaqueteRepository, PaqueteRepository>();
builder.Services.AddScoped<IRemitenteRepository, RemitenteRepsository>();
builder.Services.AddScoped<IDestinarioRepository, DestinarioRepsository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSwaggerService();
builder.Services.AddMappingService();
builder.Services.AddCorsService();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
