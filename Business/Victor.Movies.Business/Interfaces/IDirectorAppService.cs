using Victor.Movies.Business.ViewModels;

namespace Victor.Movies.Business.Interfaces
{
    public interface IDirectorAppService
    {
        IEnumerable<DiretorViewModel> GetAllDirectors();
        IEnumerable<DiretorViewModel> ListById(int? id);
    }
}
