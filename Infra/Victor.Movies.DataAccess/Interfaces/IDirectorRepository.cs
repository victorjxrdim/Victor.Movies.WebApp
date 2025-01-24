using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Interfaces
{
    public interface IDirectorRepository
    {
        IEnumerable<Diretor> GetAllDirectors();
        IEnumerable<Diretor> ListById(int? id);
    }
}
