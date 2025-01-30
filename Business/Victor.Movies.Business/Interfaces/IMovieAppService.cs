using Victor.Movies.Business.DTOs;
using Victor.Movies.Business.ViewModels;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.Business.Interfaces
{
    public interface IMovieAppService
    {
        IEnumerable<CompleteMovieDTO> ListMovieInformations(int? id = null);
        IEnumerable<CompleteMovieDTO> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null);
    }
}
