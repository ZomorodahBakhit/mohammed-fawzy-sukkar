using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoWrapper;
using Microsoft.EntityFrameworkCore;
using UniSystemApi.Core.Modules;
using UniSystemApi.Data;
using UniSystemApi.Data.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepositoryModule());
    containerBuilder.RegisterModule(new ServiceModule());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("UniSystemApi.Data")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseApiResponseAndExceptionWrapper();

app.UseAuthorization();

app.MapControllers();

app.Run();
