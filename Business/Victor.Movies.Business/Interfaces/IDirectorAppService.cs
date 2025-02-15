using Victor.Movies.Business.ViewModels;

namespace Victor.Movies.Business.Interfaces
{
    public interface IDirectorAppService
    {
        Task<IEnumerable<DiretorViewModel>> GetAllDirectors();
        Task<IEnumerable<DiretorViewModel>> ListById(int? id);
    }
}
