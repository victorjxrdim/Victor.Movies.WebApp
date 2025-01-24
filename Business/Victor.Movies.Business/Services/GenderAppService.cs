using Microsoft.Extensions.DependencyInjection;
using Victor.Movies.Business.Interfaces;
using Victor.Movies.Business.ViewModels;
using Victor.Movies.DataAccess.Interfaces;

namespace Victor.Movies.Business.Services
{
    public class GenderAppService : IGenderAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public GenderAppService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<GeneroViewModel> ListAllGender()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var genderRepository = scope.ServiceProvider.GetRequiredService<IGenderRepository>();

                var genderList = genderRepository.ListAllGender();

                return genderList.Select(g => new GeneroViewModel
                {
                    GenderId = g.GenderId,
                    Gender = g.Gender,
                });
            }
        }
    }
}
