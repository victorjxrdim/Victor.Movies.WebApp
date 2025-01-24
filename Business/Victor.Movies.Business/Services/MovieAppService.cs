using Microsoft.Extensions.DependencyInjection;
using Victor.Movies.Business.DTOs;
using Victor.Movies.Business.Interfaces;
using Victor.Movies.Business.ViewModels;
using Victor.Movies.DataAccess.Interfaces;

namespace Victor.Movies.Business.Services
{
    public class MovieAppService : IMovieAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MovieAppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<FilmeViewModel> GetAllMovies()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

                var allMoviesList = movieRepository.GetAllMovies();

                return allMoviesList.Select(m => new FilmeViewModel
                {
                    MovieId = m.MovieId,
                    MovieName = m.MovieName,
                    MovieYear = m.MovieYear,
                    MovieDirector = m.MovieDirector,
                    MovieImg = m.MovieImg,
                    GenderId = m.GenderId,
                });
            }
        }

        public IEnumerable<CompleteMovieDTO> ListMovieInformations()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

                var allMoviesList = movieRepository.ListMovieInformations();

                return allMoviesList.Select(m => new CompleteMovieDTO
                {
                    MovieId = m.MovieId,
                    MovieName = m.MovieName,
                    MovieYear = m.MovieYear,
                    MovieImg = m.MovieImg,
                    Gender = m.Gender,
                    Nome = m.Nome,
                });
            }
        }

        public IEnumerable<CompleteMovieDTO> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

                var allMoviesList = movieRepository.ListMovieInformations();

                return allMoviesList.Select(m => new CompleteMovieDTO
                {
                    MovieId = m.MovieId,
                    MovieName = m.MovieName,
                    MovieYear = m.MovieYear,
                    MovieImg = m.MovieImg,
                    Gender = m.Gender,
                    Nome = m.Nome,
                });
            }
        }
    }
}
