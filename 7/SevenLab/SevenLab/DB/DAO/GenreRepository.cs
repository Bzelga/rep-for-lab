using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenLab
{
    public class GenreRepository
    {
        private readonly GameDBContext _gameDBContext;

        public GenreRepository(GameDBContext gameDBContext)
        {
            _gameDBContext = gameDBContext;
        }

        public List<Genre> GetAllGenreOnly()
        {
            return _gameDBContext.Genres.ToList();
        }

        public List<Genre> GetAllGenreWithGames()
        {
            return _gameDBContext.Genres
                .Include(d => d.Games)
                .ToList();
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            await _gameDBContext.Genres.AddAsync(genre);
            await _gameDBContext.SaveChangesAsync();
            return genre;
        }
    }
}
