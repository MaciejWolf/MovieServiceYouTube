﻿using DomainLayer.Managers.DataLayer.DataManagers;
using DomainLayer.Managers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.Managers.DataLayer
{
    internal sealed class DataFacade
    {
        private readonly string _dbConnectionString;
        private MovieDataManager _movieDataManager;

        private MovieDataManager MovieDataManager { get { return _movieDataManager ?? (_movieDataManager = new MovieDataManager(_dbConnectionString)); } }

        public DataFacade(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public Task<int> CreateMovie(Movie movie)
        {
            return MovieDataManager.CreateMovie(movie);
        }

        public Task<Movie> GetMovieById(int id)
        {
            return MovieDataManager.GetMovieById(id);
        }

        public Task<IEnumerable<Movie>> GetAllMovies()
        {
            return MovieDataManager.GetAllMovies();
        }
    }
}
