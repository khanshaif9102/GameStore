using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Models;

namespace GameStore.API.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGameById";
        private static readonly List<GameDto> games = [
new(1,"Street Fighter II","Fighting",19.99M,new DateOnly(1992,7,15)),

new(2, "Super Mario World", "Platformer", 29.99M, new DateOnly(1990, 11, 21)),

new(3, "The Legend of Zelda: Ocarina of Time", "Action-Adventure", 39.99M, new DateOnly(1998, 11, 21)),

new(4, "Doom", "First-Person Shooter", 14.99M, new DateOnly(1993, 12, 10)),

new(5, "Final Fantasy VII", "RPG", 49.99M, new DateOnly(1997, 1, 31)),

new(6, "Minecraft", "Sandbox", 26.95M, new DateOnly(2011, 11, 18)),

new(7, "Tetris", "Puzzle", 9.99M, new DateOnly(1984, 6, 6)),

new(8, "Half-Life 2", "First-Person Shooter", 19.99M, new DateOnly(2004, 11, 16)),

new(9, "Stardew Valley", "Simulation", 14.99M, new DateOnly(2016, 2, 26)),

new(10, "Pac-Man", "Maze", 4.99M, new DateOnly(1980, 5, 22)),

new(11, "Chrono Trigger", "RPG", 19.99M, new DateOnly(1995, 3, 11)),

new(12, "Halo: Combat Evolved", "First-Person Shooter", 29.99M, new DateOnly(2001, 11, 15)),

new(13, "Castlevania: Symphony of the Night", "Action-RPG", 14.99M, new DateOnly(1997, 3, 20)),

new(14, "Portal", "Puzzle-Platformer", 9.99M, new DateOnly(2007, 10, 10)),

new(15, "Super Metroid", "Action-Adventure", 19.99M, new DateOnly(1994, 3, 19))
];

        public static void MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/games");

            //GET /games
            group.MapGet("/", () => games);



            //GET /games/{id}
            group.MapGet("/{id}", (int id) =>
            {
                var game = games.Find(g => g.Id == id);
                return game is null ? Results.NotFound() : Results.Ok(game);

            }).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", (CreateGameDto newGame,GameStoreContext dbContext) =>
            {

                Game game = new()
                {
                    Name = newGame.Name,
                    GenreId = newGame.GenreId,
                    Price = newGame.Price,
                    ReleaseDate = newGame.ReleaseDate,
                };
                
                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                GameDetailsDto gameDetailsDto = new(  game.Id,
                    game.Name,
                    game.GenreId,
                   game.Price,
                   game.ReleaseDate);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameDetailsDto.Id }, gameDetailsDto);
            });

            //PUT /games/{id}
            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
            {
                int idex = games.FindIndex(g => g.Id == id);
                if (idex == -1)
                {
                    return Results.NotFound();
                }
                else
                {
                    games[idex] = new GameDto(
                      id,
                      updatedGame.Name,
                      updatedGame.Genre,
                      updatedGame.Price,
                      updatedGame.ReleaseDate
                    );
                    return Results.NoContent();
                }
            });

            //DELETE /games/{id}
            group.MapDelete("/{id}", (int id) =>
            {
                var removedCount = games.RemoveAll(g => g.Id == id);
                return removedCount > 0 ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
