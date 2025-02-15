﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllDirectors(int? id = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var diretorAppService = scope.ServiceProvider.GetRequiredService<IDirectorAppService>();

                if(id != null)
                {
                    var directorListById = await diretorAppService.ListById(id);
                    
                    return Ok(directorListById);
                }
                else
                {
                    var directorList = await diretorAppService.GetAllDirectors();

                    return Ok(directorList);
                }
            }
        }

        [HttpGet("ListMovieInformations")]
        [HttpGet("ListMovieInformationById/{id}")]
        public async Task<IActionResult> ListMovieInformations(int? id = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieAppService = scope.ServiceProvider.GetRequiredService<IMovieAppService>();

                var allMoviesInformationList = await movieAppService.ListMovieInformations(id);

                if(id != null)
                {
                    return PartialView("/Views/Home/_ModalMoreInformation.cshtml", allMoviesInformationList.FirstOrDefault(x => x.MovieId == id));

                }
                else
                {
                    return Json(allMoviesInformationList);
                }
            }
        }

        [HttpGet("MovieFilter")]
        public IActionResult MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var movieAppService = scope.ServiceProvider.GetRequiredService<IMovieAppService>();

                var movieFilterList = movieAppService.MovieFilter(gender, director, movie, year);

                return Json(movieFilterList);
            }
        }
        #endregion
    }
}
