using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	[Route("/")]
	[ApiController]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
