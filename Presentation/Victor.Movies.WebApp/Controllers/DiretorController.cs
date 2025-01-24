using Microsoft.AspNetCore.Mvc;
using Victor.Movies.Business.Interfaces;

namespace Victor.Movies.WebApi.Controllers
{
    [Route("[controller]")]
    public class DiretorController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public DiretorController(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

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
    }
}
