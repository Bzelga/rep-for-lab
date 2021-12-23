using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenLab
{
    public class DeveloperRepository
    {
        private readonly GameDBContext _gameDBContext;

        public DeveloperRepository(GameDBContext gameDBContext)
        {
            _gameDBContext = gameDBContext;
        }

        public List<Developers> GetDevelopers()
        {
            return _gameDBContext.Developers.ToList();
        }

        public async Task<Developers> CreateDeveloper(Developers developer)
        {
            await _gameDBContext.Developers.AddAsync(developer);
            await _gameDBContext.SaveChangesAsync();
            return developer;
        }

        public async Task<Developers> ChangeDevNameById(int id, string newName)
        {
            var result = _gameDBContext.Developers.SingleOrDefault(e => e.DeveloperId == id);
            if (result != null)
            {
                result.Name = newName;
                await _gameDBContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<string> DeleteDevById(int id)
        {
            var result = _gameDBContext.Developers.SingleOrDefault(e => e.DeveloperId == id);
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
