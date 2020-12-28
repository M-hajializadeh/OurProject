using MA.Models;
using MA.Models.ViewModels;
using MA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IProductService _IPS;
        private readonly IMainGroupService _IMGS;
        public DetailsController(IProductService ips, IMainGroupService mainGroupService)
        {
            this._IPS = ips;
            this._IMGS = mainGroupService;
        }
        public async Task<IActionResult> Index(int id)
        {
            Product product = await _IPS.GetProductByIdAsync(id);
            MainGroup mainGroup = await _IMGS.GetMainGroupByIdAsync(product.MainGroupID);
            ProductViewModel model = new ProductViewModel
            {
                ID=product.ID,
                Count=product.Count,
                Description=product.Description,
                Off=product.Off,
                PictureUrl=product.PictureUrl,
                ProductName=product.ProductName,
                Price=product.Price,
                GroupId=mainGroup.Id,
                GroupName=mainGroup.GroupName
            };
            return View(model);
        }
    }
}
