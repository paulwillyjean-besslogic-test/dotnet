using Microsoft.EntityFrameworkCore;
using app.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opts => {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddDbContext<AircraftContext>(opt => {
    string? connectionString = builder.Configuration.GetConnectionString("DefaultDb");
    Console.WriteLine(connectionString);
    opt.UseSqlServer(connectionString ?? throw new Exception("Connection string is empty."));
});
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

// app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
// app.UseAuthorization();

app.MapControllers();

app.Run();
