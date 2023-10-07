using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Models;

namespace TesteSmartHint.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Register() => View();

        public IActionResult Save(CustomerRegisterViewModel customer)
        {
            return RedirectToAction("Index");
        }
    }
}
