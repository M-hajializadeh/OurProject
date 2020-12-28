using MA.Models;
using MA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _IPS;
        public HomeController(IProductService ips)
        {
            this._IPS = ips;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _IPS.GetProductAsync(Common.SortMethod.SelectSortMethod.OrderByDescending);
            return View(products);
        }

       
    }
}
