using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA.Models;
using MA.Common;

namespace MA.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync(SortMethod.SelectSortMethod sortMethod = SortMethod.SelectSortMethod.OrderByAscending);
        Task<Product> GetProductByIdAsync(int id);
    }
}
