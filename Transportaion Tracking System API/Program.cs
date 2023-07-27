using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Transportaion_Tracking_System_API.Data;
using Transportaion_Tracking_System_API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()

.AddFluentValidation(fv =>
 {
     fv.RegisterValidatorsFromAssemblyContaining<VehicleValidator>();
     fv.RegisterValidatorsFromAssemblyContaining<TransportValidator>();
 });

builder.Services.AddDbContext<VehicleAndTransportDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleAndTransport"));
});

//builder.Configuration.GetConnectionString("SqlConnectionString");
//builder.Services.AddDbContext<VehicleAndTransportDbContext>(options => options.UseSqlServer("VehicleAndTransport"));


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
