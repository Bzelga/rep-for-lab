using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrelastLab.Server
{
    public class Query
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameOnly([Service] GameRepository gameRepository) =>
            gameRepository.GetGame();

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameWithDevGerne([Service] GameRepository gameRepository) =>
            gameRepository.GetGameWithGerneDeveloper();

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Genre> AllGenreOnly([Service] GenreRepository genreRepository) =>
            genreRepository.GetAllGenreOnly();

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Genre> AllGenreWithGame([Service] GenreRepository genreRepository) =>
            genreRepository.GetAllGenreWithGames();

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Developers> AllDeveloperOnly([Service] DeveloperRepository developerRepository) =>
            developerRepository.GetAllDeveloperOnly();

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Developers> AllDeveloperWithGame([Service] DeveloperRepository developerRepository) =>
            developerRepository.GetAllDeveloperWithGames();

    }
}
