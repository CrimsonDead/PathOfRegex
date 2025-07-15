using Microsoft.EntityFrameworkCore;
using PathOfRegexDB;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(o =>
{
    o.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 42)));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
