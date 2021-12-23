﻿using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Collections.Generic;

namespace SevenLab
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameOnly([Service] GameRepository gameRepository) =>
            gameRepository.GetGames();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Games> AllGameWithDevGerne([Service] GameRepository gameRepository) =>
            gameRepository.GetGameWithGerneDeveloper();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Genre> AllGenre([Service] GenreRepository genreRepository) =>
            genreRepository.GetGenres();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public List<Developers> AllDeveloper([Service] DeveloperRepository developerRepository) =>
            developerRepository.GetDevelopers();
    }
}
