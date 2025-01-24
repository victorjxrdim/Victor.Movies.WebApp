using Victor.Movies.Business.DTOs;
using Victor.Movies.Business.ViewModels;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.Business.Interfaces
{
    public interface IMovieAppService
    {
        IEnumerable<FilmeViewModel> GetAllMovies();
        IEnumerable<CompleteMovieDTO> ListMovieInformations();
        IEnumerable<CompleteMovieDTO> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null);
    }
}
