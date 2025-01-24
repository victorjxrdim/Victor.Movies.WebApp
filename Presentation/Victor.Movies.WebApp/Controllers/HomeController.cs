using Microsoft.AspNetCore.Mvc;
using Victor.Movies.Business.Interfaces;

namespace Victor.Movies.WebApi.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
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
    }
}
