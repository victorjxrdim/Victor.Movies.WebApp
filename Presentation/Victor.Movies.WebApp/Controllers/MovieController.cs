using Microsoft.AspNetCore.Mvc;
using Victor.Movies.Business.Interfaces;

namespace Victor.Movies.WebApi.Controllers
{
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        public MovieController(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

        #region Pages
        [HttpGet("")]
        [HttpGet("Movies")]
        public IActionResult Movies()
        {
            return View("/Views/Home/Movies.cshtml");
        }
        #endregion

        #region API's
        [HttpGet("ListById/{id}")]
        [HttpGet("GetAllDirectors")]
        public IActionResult GetAllDirectors(int? id = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var diretorAppService = scope.ServiceProvider.GetRequiredService<IDirectorAppService>();

                if(id != null)
                {
                    var directorListById = diretorAppService.ListById(id);
                    
                    return Ok(directorListById);
                }
                else
                {
                    var directorList = diretorAppService.GetAllDirectors();

                    return Ok(directorList);
                }
            }
        }


        [HttpGet("GetAllMovies")]
        public IActionResult GetAllMovies()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieAppService = scope.ServiceProvider.GetRequiredService<IMovieAppService>();

                var allMoviesList = movieAppService.GetAllMovies();

                return Ok(allMoviesList);
            }
        }

        [HttpGet("ListMovieInformations")]
        public IActionResult ListMovieInformations()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieAppService = scope.ServiceProvider.GetRequiredService<IMovieAppService>();

                var allMoviesInformationList = movieAppService.ListMovieInformations();

                return Ok(allMoviesInformationList);
            }
        }

        [HttpGet("MovieFilter")]
        public IActionResult MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieAppService = scope.ServiceProvider.GetRequiredService<IMovieAppService>();

                var movieFilterList = movieAppService.MovieFilter(gender, director, movie, year);

                return Ok(movieFilterList);
            }
        }
        #endregion
    }
}
