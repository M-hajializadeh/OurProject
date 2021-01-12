using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA.Models;

namespace MA.Services
{
    public class OptionalItemService : IOptionalItemService
    {
        private readonly ApplicationDbContext _context;
        public OptionalItemService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Insert(OptionalItem item)
        {
            if (item != null)
            {
                _context.Tbl_OptionalItems.Add(item);
                SaveChange();
            }

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }


        public async Task InsertAsync(OptionalItem item)
        {
            if (item != null)
            {
                await _context.Tbl_OptionalItems.AddAsync(item);
                await SaveChangeAsync();
            }
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
