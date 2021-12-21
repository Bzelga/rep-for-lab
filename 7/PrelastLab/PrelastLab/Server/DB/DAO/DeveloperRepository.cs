using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrelastLab.Server
{
    public class DeveloperRepository
    {
        private readonly GameDBContext _gameDBContext;

        public DeveloperRepository(GameDBContext gameDBContext)
        {
            _gameDBContext = gameDBContext;
        }

        public List<Developers> GetAllDeveloperOnly()
        {
            return _gameDBContext.Developers.ToList();
        }

        public List<Developers> GetAllDeveloperWithGames()
        {
            return _gameDBContext.Developers
                .Include(d => d.Games)
                .ToList();
        }

        public async Task<Developers> CreateDeveloper(Developers developer)
        {
            await _gameDBContext.Developers.AddAsync(developer);
            await _gameDBContext.SaveChangesAsync();
            return developer;
        }
    }
}
