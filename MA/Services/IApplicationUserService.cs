using MA.Models;
using MA.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUserViewModel>> GetAllUserAsync();
        Task<ApplicationUserViewModel> GetUserByNameAsync(string userName);
        Task<ApplicationUserViewModel> GetUserByIdAsync(string ID);
        Task AddUserAsync(ApplicationUserViewModel model);
    }
}
