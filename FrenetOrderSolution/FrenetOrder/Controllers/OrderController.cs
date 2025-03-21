using Microsoft.AspNetCore.Mvc;

namespace FrenetOrder.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
