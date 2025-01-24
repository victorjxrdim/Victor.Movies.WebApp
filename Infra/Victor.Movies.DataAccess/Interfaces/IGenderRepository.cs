using Victor.Movies.DataAccess.Models;

namespace Victor.Movies.DataAccess.Interfaces
{
    public interface IGenderRepository
    {
        IEnumerable<Genero> ListAllGender();
    }
}
