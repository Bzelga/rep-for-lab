using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenLab
{
    public class GameRepository
    {
        private readonly GameDBContext _gameDBContext;

        public GameRepository(GameDBContext gameDBContext)
        {
            _gameDBContext = gameDBContext;
        }

        public List<Games> GetGames()
        {
            return _gameDBContext.Games.ToList();
        }

        public List<Games> GetGameWithGerneDeveloper()
        {
            return _gameDBContext.Games
                .Include(e => e.Genre)
                .Include(e => e.Developer)
                .ToList();
        }

        public async Task<Games> CreateGame(Games employee)
        {
            await _gameDBContext.Games.AddAsync(employee);
            await _gameDBContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Games> ChangeGamePriceById(int id, double newPrice)
        {
            var result = _gameDBContext.Games.SingleOrDefault(e => e.GamesId == id);
            if(result!= null)
            {
                result.Price = newPrice;
                await _gameDBContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<string> DeleteGameById(int id)
        {
            var result = _gameDBContext.Games.SingleOrDefault(e => e.GamesId == id);
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
