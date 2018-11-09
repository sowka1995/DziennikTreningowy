using Microsoft.AspNetCore.Mvc;

namespace DziennikTreningowy.Controllers
{
    [Produces("application/json")]
    [Route("/")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private const string SwaggerUri = "~/swagger";

        [HttpGet]
        public ActionResult Index()
        {
            return new RedirectResult(SwaggerUri);
        }
    }

}
