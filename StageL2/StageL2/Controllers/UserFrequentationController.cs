using Microsoft.AspNetCore.Mvc;

namespace StageL2.Controllers
{
    public class UserFrequentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}