using Microsoft.Extensions.DependencyInjection;
using Victor.Movies.Business.Interfaces;
using Victor.Movies.Business.ViewModels;
using Victor.Movies.DataAccess.Interfaces;

namespace Victor.Movies.Business.Services
{
    public class DirectorAppService : IDirectorAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public DirectorAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<DiretorViewModel>> GetAllDirectors()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var diretorRepository = scope.ServiceProvider.GetRequiredService<IDirectorRepository>();
                var directors = await diretorRepository.GetAllDirectors();

                return directors.Select(d => new DiretorViewModel
                {
                    Id = d.Id,
                    Nome = d.Nome
                }).ToList();
            }
        }

        public async Task<IEnumerable<DiretorViewModel>> ListById(int? id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var diretorRepository = scope.ServiceProvider.GetRequiredService<IDirectorRepository>();
                var directorById = await diretorRepository.ListById(id);

                return directorById.Select(d => new DiretorViewModel
                {
                    Id = d.Id,
                    Nome = d.Nome
                }).ToList();
            }
        }
    }
}
