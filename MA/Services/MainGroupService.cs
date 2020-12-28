using MA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Services
{
    public class MainGroupService : IMainGroupService
    {
        private readonly ApplicationDbContext _Context;
        public MainGroupService(ApplicationDbContext context)
        {
            this._Context = context;
        }
        public async Task<MainGroup> GetMainGroupByIdAsync(int id)
        {
            var mainGroup = await _Context.Tbl_MainGroups.Where(m => m.Id.Equals(id)&& m.IsShow==true).SingleOrDefaultAsync();
            return mainGroup;
        }

        public async Task<List<MainGroup>> GetMainGroupsAsync()
        {
            List<MainGroup> model = new List<MainGroup>();
            model = await _Context.Tbl_MainGroups.Select(m => new MainGroup
            {
                Id = m.Id,
                GroupName = m.GroupName,
                IsShow=m.IsShow,
                Description=m.Description
            }).Where(m => m.IsShow == true).ToListAsync();
            return model;
        }
    }
}
