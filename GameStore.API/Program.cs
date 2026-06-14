using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Endpoints;
using GameStore.API.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.AddGameStoreDv();

var app = builder.Build();


app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
