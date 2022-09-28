using group_sv.Models;
using group_sv.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => {
    options.ListenLocalhost(5161, o=>o.Protocols = HttpProtocols.Http2);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<GroupContext>(option => {
    option.UseInMemoryDatabase("GroupDb");
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<GrpcGroupService>();
app.MapControllers();

DataPopulation.PopulateGroup(app);

app.Run();
