namespace Storagge.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var model = new HomeViewModel();
			model.Message = "Storage Application";

			return View(model);
		}
	}
}
