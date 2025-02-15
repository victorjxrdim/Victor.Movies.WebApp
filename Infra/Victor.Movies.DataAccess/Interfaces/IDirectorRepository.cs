using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Diretor>> GetAllDirectors();
        Task<IEnumerable<Diretor>> ListById(int? id);
    }
}
