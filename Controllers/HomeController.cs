using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace tclk.Controllers {
    public class HomeController : Controller {
        //
        // Get: "/"
        public IActionResult Index() {
            return View();
        }
        //
        // Get: "/cams/"
        public IActionResult Cams() {
            return View();
        }
    }
}