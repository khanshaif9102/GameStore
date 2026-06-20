using GameStore.API.Data;
using GameStore.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints
{
    public static class GenresEndpoints
    {
        public static void MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/genres");

            //Get all genres
            group.MapGet("/", async (GameStoreContext context) =>
                         await context.Genres.Select(g => new GenreDto(g.Id, g.Name)).AsNoTracking().ToListAsync()
            );
        }
    }
}
