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

        public List<Genre> GetGenres()
        {
            return _gameDBContext.Genres.ToList();
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            await _gameDBContext.Genres.AddAsync(genre);
            await _gameDBContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> ChangeGenreNameById(int id, string newName)
        {
            var result = _gameDBContext.Genres.SingleOrDefault(e => e.GenreId == id);
            if (result != null)
            {
                result.Name = newName;
                await _gameDBContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<string> DeleteGenreById(int id)
        {
            var result = _gameDBContext.Genres.SingleOrDefault(e => e.GenreId == id);
            if (result != null)
            {
                _gameDBContext.Entry(result).State = EntityState.Deleted;
                await _gameDBContext.SaveChangesAsync();
                return "done";
            }
            return "fall";
        }
    }
}
