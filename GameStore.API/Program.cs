using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data Source=GameStore.db";
builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlite(connString));

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
