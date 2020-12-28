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
        public OptionalItemController(IMainGroupService mainGroupService)
        {
            this._IMGS = mainGroupService;
        }
        public async Task<IActionResult> Index()
        {
            List<MainGroup> mainGroups = await _IMGS.GetMainGroupsAsync();
            return View(mainGroups);
        }
    }
}
