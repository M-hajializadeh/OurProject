using MA.Models;
using MA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Controllers
{
    public class OptionalItemController : Controller
    {
        private readonly IMainGroupService _IMGS;
        private readonly IOptionalItemService _IOIS;
        public OptionalItemController(IMainGroupService mainGroupService, IOptionalItemService optionalService)
        {
            this._IMGS = mainGroupService;
            this._IOIS = optionalService;
        }
        public async Task<IActionResult> Index()
        {
            List<MainGroup> mainGroups = await _IMGS.GetMainGroupsAsync();
            return View(mainGroups);
        }

        public async Task<IActionResult> AddRequest(OptionalItem model)
        {
            if (ModelState.IsValid)
            {
                var item =  new OptionalItem()
                {
                    ID=model.ID,
                    AttachFileURL=model.AttachFileURL,
                    Customer=model.Customer,
                    CustomerID=model.CustomerID,
                    Description=model.Description,
                    Details=model.Details
                };
            }
            return null;
        }
    }
}
