using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Bugtracker.Controllers {
    public class DashboardController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}