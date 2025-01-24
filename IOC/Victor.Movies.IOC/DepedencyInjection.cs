using Microsoft.Extensions.DependencyInjection;
using Victor.Movies.Business.Interfaces;
using Victor.Movies.Business.Services;
using Victor.Movies.DataAccess.Interfaces;
using Victor.Movies.DataAccess.Data.Repositories;
using Victor.Movies.DataAccess.Utils;

namespace Victor.Movies.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection StartInjection(this IServiceCollection services)
        {
            #region App Service
            services.AddScoped<IDirectorAppService, DirectorAppService>();
            services.AddScoped<IMovieAppService, MovieAppService>();
            services.AddScoped<IGenderAppService, GenderAppService>();
            #endregion

            #region Repositories
            services.AddScoped<ConnectionClass>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            #endregion

            return services;
        }
    }
}
