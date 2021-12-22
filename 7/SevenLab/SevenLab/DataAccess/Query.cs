using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenLab
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameOnly([Service] GameRepository gameRepository) =>
            gameRepository.GetGame();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameWithDevGerne([Service] GameRepository gameRepository) =>
            gameRepository.GetGameWithGerneDeveloper();

        [UseFiltering]
        public async Task<Games> GetEmployeeById([Service] GameRepository gameRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Games gottenEmployee = gameRepository.GetGameById(id);
            await eventSender.SendAsync("ReturnedGame", gottenEmployee);
            return gottenEmployee;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Genre> AllGenreOnly([Service] GenreRepository genreRepository) =>
            genreRepository.GetAllGenreOnly();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Genre> AllGenreWithGame([Service] GenreRepository genreRepository) =>
            genreRepository.GetAllGenreWithGames();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Developers> AllDeveloperOnly([Service] DeveloperRepository developerRepository) =>
            developerRepository.GetAllDeveloperOnly();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Developers> AllDeveloperWithGame([Service] DeveloperRepository developerRepository) =>
            developerRepository.GetAllDeveloperWithGames();

    }
}
