using Microsoft.EntityFrameworkCore;
using TaskboardAPI.Data;
using TaskboardAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddSqlite<ApplicationContext>(connection);
var app = builder.Build();
app.MigrateDatabase();
app.MapBoardEndpoint();
app.MapCardEndpoint();
app.MapColumnEndpoint();

app.Run();
