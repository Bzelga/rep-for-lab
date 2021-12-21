using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace PrelastLab.Server
{
    public class Mutation
    {
        public async Task<Genre> CreateGenre([Service] GenreRepository genreRepository,
            [Service] ITopicEventSender eventSender, string gerneName)
        {
            var newGenre = new Genre
            {
                Name = gerneName
            };
            var createdGenre = await genreRepository.CreateGenre(newGenre);

            await eventSender.SendAsync("GenreCreated", createdGenre);

            return createdGenre;
        }

        public async Task<Developers> CreateDeveloper([Service] DeveloperRepository devRepository,
            [Service] ITopicEventSender eventSender, string nameDev, string countryDev)
        {
            var newDeveloper = new Developers
            {
                Name = nameDev,
                Country = countryDev
            };
            var createdDev = await devRepository.CreateDeveloper(newDeveloper);

            await eventSender.SendAsync("DeveloperCreated", createdDev);

            return createdDev;
        }

        public async Task<Games> CreateGameWithDeveloperGenreId([Service] GameRepository gameRepository,
           string name, double price, int idDev, int idGenre)
        {
            Games newGame = new Games
            {
                Name = name,
                GenreId = idGenre,
                DeveloperId = idDev,
                Price = price
            };

            var createdGame = await gameRepository.CreateGame(newGame);
            return createdGame;
        }

        public async Task<Games> CreateGameWithDeveloperGenre([Service] GameRepository gameRepository,
            string name, double price, string gerneName, string nameDev, string countryDev)
        {
            Games newGame = new Games
            {
                Name = name,
                Genre = new Genre { Name = gerneName },
                Developer= new Developers { Name = nameDev, Country = countryDev },
                Price = price
            };

            var createdGame = await gameRepository.CreateGame(newGame);
            return createdGame;
        }

        public async Task<Games> ChangeGamePriceById([Service] GameRepository gameRepository,
            int id, double newPrice)
        {
            var changedGame = await gameRepository.ChangeGamePriceById(id, newPrice);
            return changedGame;
        }

        public async Task<string> DeleteGameById([Service] GameRepository gameRepository,
           int id)
        {
            var resultDeleteGame = await gameRepository.DeleteGameById(id);
            return resultDeleteGame;
        }
    }
}
