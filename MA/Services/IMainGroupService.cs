using MA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public interface IMainGroupService
    {
        Task<List<MainGroup>> GetMainGroupsAsync();
        Task<MainGroup> GetMainGroupByIdAsync(int id);
    }
}
