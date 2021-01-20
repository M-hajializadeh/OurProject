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
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IApplicationRoleService _IRoleService;
        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IApplicationRoleService roleService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._IRoleService = roleService;
        }

        public async Task<List<ApplicationUserViewModel>> GetAllUserAsync()
        {
            List<ApplicationUserViewModel> models = new List<ApplicationUserViewModel>();
            models = await _userManager.Users.Select(u => new ApplicationUserViewModel
            {
                ID=u.Id,
                Email=u.Email,
                Password=u.PasswordHash,
                PhoneNumber=u.PhoneNumber,
                UserName=u.UserName,                
            }).ToListAsync();
            return models;
        }

        public async Task<ApplicationUserViewModel> GetUserByIdAsync(string ID)
        {
            ApplicationUserViewModel model = await _userManager.Users.Select(u => new ApplicationUserViewModel
            {
                ID = u.Id,
                Email = u.Email,
                Password = u.PasswordHash,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).Where(u => u.ID.Equals(ID)).FirstOrDefaultAsync();
            return model;
        }

        public async Task<ApplicationUserViewModel> GetUserByNameAsync(string userName)
        {
            ApplicationUserViewModel model = await _userManager.Users.Select(u => new ApplicationUserViewModel
            {
                ID = u.Id,
                Email = u.Email,
                Password = u.PasswordHash,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).Where(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
            return model;
        }

        public async Task AddUserAsync(ApplicationUserViewModel model)
        {
            if (model!=null)
            {
                ApplicationUser user = new ApplicationUser
                {
                   UserName=model.UserName,
                   Email=model.Email,
                   PasswordHash=model.Password,
                   PhoneNumber=model.PhoneNumber
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    //Add feature to get role user in user viewModel
                    //var appRole = await _IRoleService.GetRoleByIdAsync(model.ID);
                    //var appRole = await _roleManager.FindByIdAsync(model.ID);
                }
            }
            
        }
    }
}
