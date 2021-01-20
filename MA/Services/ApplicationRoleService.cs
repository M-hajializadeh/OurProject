using MA.Models;
using MA.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public class ApplicationRoleService:IApplicationRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public ApplicationRoleService(RoleManager<ApplicationRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<List<ApplicationRoleViewModel>> GetAllRoleAsync()
        {
            List<ApplicationRoleViewModel> models = new List<ApplicationRoleViewModel>();
            models = await _roleManager.Roles.Select(r => new ApplicationRoleViewModel
            {
                ID = r.Id,
                Name = r.Name
            }).ToListAsync();
            return models;
        }

        public async Task<ApplicationRoleViewModel> GetRoleByIdAsync(string ID)
        {
            ApplicationRoleViewModel model = await _roleManager.Roles.Select(r => new ApplicationRoleViewModel
            {
                ID=r.Id,
                Name=r.Name
            }).Where(ro=>ro.ID.Equals(ID)).SingleOrDefaultAsync();
            return model;
        }

        public async Task<ApplicationRoleViewModel> GetRoleByNameAsync(string name)
        {
            ApplicationRoleViewModel model = await _roleManager.Roles.Select(r => new ApplicationRoleViewModel
            {
                ID = r.Id,
                Name = r.Name
            }).Where(ro => ro.Name.Equals(name)).SingleOrDefaultAsync();
            return model;
        }
    }
}
