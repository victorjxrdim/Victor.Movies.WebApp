using Victor.Movies.DataAccess.DTOs;
using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Interfaces
{
    public interface IMovieRepository 
    {
        IEnumerable<CompleteMovieDTO> ListMovieInformations(int? id = null);
        IEnumerable<CompleteMovieDTO> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null);
    }
}
