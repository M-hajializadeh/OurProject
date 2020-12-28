using MA.Models;
using MA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IProductService _IPS;
        private readonly ICookiesService _Cookies;
        public PaymentController(IProductService productService, ICookiesService cookies)
        {
            this._IPS = productService;
            this._Cookies = cookies;
        }
        public async Task<IActionResult> Index()
        {
            var ids = _Cookies.GetListItem("CartList");
            List<Product> products = new List<Product>();
            foreach (var item in ids)
            {
                products.Add(await _IPS.GetProductByIdAsync(Convert.ToInt32(item)));
            }
            return View(products??null);
        }
        public IActionResult Sell()
        {

            return View();
        }
    }
}
