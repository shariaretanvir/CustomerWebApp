using CustomerApp.API.Extensions;
using CustomerApp.API.Middlewares;
using CustomerApp.Core.Infrastructure;
using CustomerApp.Infrastructure.Common;
using CustomerApp.Infrastructure.Data;
using CustomerApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GlobalExceptionMiddleware>();

builder.Services.CustomCORS();
builder.Services.MapperConfig();
builder.Services.MediatRConfig();
builder.Services.ValidatorConfig();

builder.Services.AddDbContext<CustomerDbContext>(ops =>
{
    ops.UseSqlServer(builder.Configuration["ConnectionStrings:CustomerConnectionString"]).EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<CustomerRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Scan(scan => scan.FromAssemblies(AppDomain.CurrentDomain.Load("CustomerApp.Infrastructure"))
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithTransientLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCustomCorsPolicy");
app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
