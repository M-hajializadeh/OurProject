using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string userName)
        {
            if (userName!=null)
            {

            }
            return null;
        }

        public IActionResult Verify()
        {
            return View();
        }
        public IActionResult Confirm()
        {
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
