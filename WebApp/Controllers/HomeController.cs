using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	[Route("/")]
	[Controller]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
