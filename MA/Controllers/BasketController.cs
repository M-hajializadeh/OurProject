using MA.Models;
using MA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICookiesService _Cookies;
        private readonly IProductService _IPS;
        public BasketController(ICookiesService cookies, IProductService productService)
        {
            this._Cookies = cookies;
            this._IPS = productService;
        }
        public async Task<IActionResult> Index()
        {
            var productId = _Cookies.GetListItem("CartList");
            List<Product> proudctDetails = new List<Product>();
            if (productId!=null)
            {
                foreach (var item in productId)
                {
                    if (await _IPS.GetProductByIdAsync(Convert.ToInt32(item)) != null)
                        proudctDetails.Add(await _IPS.GetProductByIdAsync(Convert.ToInt32(item)));
                }
            }
            return View(proudctDetails??null);
        }
        [HttpPost]
        public IActionResult AddCart(int id)
        {
            try
            {
                _Cookies.Set("CartList", id.ToString(), 30);
                Common.BasketCount.Count++;
                return Json(new { status = "success", message = "محصول به سبد خرید افزوده شد", count=Common.BasketCount.Count.ToString() });
            }
            catch (Exception)
            {
                return Json(new { status = "faild", message = "در ثبت محصول مشکلی پیش آمد" });
            }
            
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                _Cookies.Delete("CartList", id.ToString());
                Common.BasketCount.Count--;
                return Json(new { status = "success", message = "محصول از سبد خرید حذف شد", count = Common.BasketCount.Count.ToString() });
            }
            catch (Exception)
            {

                return Json(new { status = "faild", message = "در حذف محصول مشکلی پیش آمد" });
            }
        }
    }
}
