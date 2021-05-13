using Microsoft.AspNetCore.Mvc;


namespace tclk.Controllers {
    public class HomeController : Controller {
        // Get: "/"
        public IActionResult Index() {
            return View();
        }
        // Get: "/cams/"
        public IActionResult Cams() {
            return View();
        }
    }
}
