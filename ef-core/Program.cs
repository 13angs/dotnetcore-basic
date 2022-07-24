
using ef_core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContextPool<EFCoreDbContext>(options => {
    // connection string 
    string Server = configuration["Mysql:Server"];
    string Port = configuration["Mysql:Port"];
    string UserId = configuration["Mysql:UserId"];
    string Password = configuration["Mysql:Password"];
    string Database = configuration["Mysql:Database"];

    string conStr = string.Format(
        "server={0},{1}; user id={2}; password={3}; database={4}",
        Server, Port, UserId, Password, Database
    );

    options.UseMySql(
        // configuration.GetConnectionString("CrmConStr"),
        conStr,
        Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(conStr)
    );
});

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
