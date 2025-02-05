using Microsoft.EntityFrameworkCore;
using TaskboardAPI.Data;
using TaskboardAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddSqlite<ApplicationContext>(connection);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MigrateDatabase();
app.MapBoardEndpoint();
app.MapCardEndpoint();
app.MapColumnEndpoint();

app.Run();
