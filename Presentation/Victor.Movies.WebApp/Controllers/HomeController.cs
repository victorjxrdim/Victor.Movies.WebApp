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
    }
}
