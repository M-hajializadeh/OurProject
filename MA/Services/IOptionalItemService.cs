using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA.Models;

namespace MA.Services
{
    public interface IOptionalItemService
    {
        void Insert(OptionalItem item);
        void SaveChange();

        Task InsertAsync(OptionalItem item);
        Task SaveChangeAsync();

    }
}
