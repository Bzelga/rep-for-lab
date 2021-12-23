using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenLab
{
    public class Mutation
    {
        public async Task<List<Genre>> CreateGenre([Service] GenreRepository genreRepository,
            [Service] ITopicEventSender eventSender, string gerneName)
        {
            var newGenre = new Genre
            {
                Name = gerneName
            };
            var createdGenre = await genreRepository.CreateGenre(newGenre);

            await eventSender.SendAsync("GenreCreated", createdGenre);

            return genreRepository.GetGenres();
        }

        public async Task<List<Developers>> CreateDeveloper([Service] DeveloperRepository devRepository,
            [Service] ITopicEventSender eventSender, string nameDev, string countryDev)
        {
            var newDeveloper = new Developers
            {
                Name = nameDev,
                Country = countryDev
            };
            var createdDev = await devRepository.CreateDeveloper(newDeveloper);

            await eventSender.SendAsync("DeveloperCreated", createdDev);

            return devRepository.GetDevelopers();
        }

        public async Task<List<Games>> CreateGameWithDeveloperGenreId([Service] GameRepository gameRepository,
            [Service] ITopicEventSender eventSender, string name, double price, int idDev, int idGenre)
        {
            Games newGame = new Games
            {
                Name = name,
                GenreId = idGenre,
                DeveloperId = idDev,
                Price = price
            };

            var createdGame = await gameRepository.CreateGame(newGame);

            await eventSender.SendAsync("GameCreated", createdGame);
            return gameRepository.GetGameWithGerneDeveloper();
        }

        public async Task<List<Games>> ChangeGamePriceById([Service] GameRepository gameRepository,
            [Service] ITopicEventSender eventSender, int id, double newPrice)
        {
            var changedGame = await gameRepository.ChangeGamePriceById(id, newPrice);
            await eventSender.SendAsync("ChangeGame", changedGame);
            return gameRepository.GetGameWithGerneDeveloper();
        }

        public async Task<List<Games>> DeleteGameById([Service] GameRepository gameRepository, 
            [Service] ITopicEventSender eventSender, int id)
        {
            var resultDeleteGame = await gameRepository.DeleteGameById(id);
            await eventSender.SendAsync("DeleteGame", resultDeleteGame);
            return gameRepository.GetGameWithGerneDeveloper();
        }

        public async Task<List<Genre>> ChangeGenreNameById([Service] GenreRepository genreRepository,
           [Service] ITopicEventSender eventSender, int id, string newName)
        {
            var changedGerne = await genreRepository.ChangeGenreNameById(id, newName);
            await eventSender.SendAsync("ChangeGenre", changedGerne);
            return genreRepository.GetGenres();
        }

        public async Task<List<Genre>> DeleteGenreById([Service] GenreRepository genreRepository,
           [Service] ITopicEventSender eventSender, int id)
        {
            var resultDeleteGenre = await genreRepository.DeleteGenreById(id);
            await eventSender.SendAsync("DeleteGenre", resultDeleteGenre);
            return genreRepository.GetGenres();
        }

        public async Task<List<Developers>> ChangeDevNameById([Service] DeveloperRepository devRepository,
           [Service] ITopicEventSender eventSender,  int id, string newName)
        {
            var changeddev = await devRepository.ChangeDevNameById(id, newName);
            await eventSender.SendAsync("ChangeDev", changeddev);
            return devRepository.GetDevelopers();
        }

        public async Task<List<Developers>> DeleteDevById([Service] DeveloperRepository devRepository,
           [Service] ITopicEventSender eventSender, int id)
        {
            var resultDeleteDev = await devRepository.DeleteDevById(id);
            await eventSender.SendAsync("DeleteDev", resultDeleteDev);
            return devRepository.GetDevelopers();
        }
    }
}
