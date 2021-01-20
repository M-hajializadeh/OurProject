using MA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public interface IApplicationRoleService
    {
        Task<List<ApplicationRoleViewModel>> GetAllRoleAsync();
        Task<ApplicationRoleViewModel> GetRoleByNameAsync(string name);
        Task<ApplicationRoleViewModel> GetRoleByIdAsync(string ID);
    }
}
