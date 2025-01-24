using Victor.Movies.Business.ViewModels;

namespace Victor.Movies.Business.Interfaces
{
    public interface IGenderAppService
    {
        IEnumerable<GeneroViewModel> ListAllGender();
    }
}
