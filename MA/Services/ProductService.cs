using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA.Models;
using Microsoft.EntityFrameworkCore;
using MA.Common;
namespace MA.Services
{
    public class ProductService : IProductService
    {
        
        private readonly ApplicationDbContext _Context;
        public ProductService(ApplicationDbContext context)
        {
            _Context = context;

        }

        public async Task<List<Product>> GetProductAsync(SortMethod.SelectSortMethod sortMethod=SortMethod.SelectSortMethod.OrderByAscending)
        {
            List<Product> model = new List<Product>();
            model = await _Context.Tbl_Products.Select(p => new Product
            {
                ID = p.ID,
                IsShow = p.IsShow,
                Count = p.Count,
                MainGroupID = p.MainGroupID,
                Off = p.Off,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                ProductName = p.ProductName
            }).Where(s => s.IsShow.Equals(true)).ToListAsync();
            if (sortMethod == SortMethod.SelectSortMethod.OrderByDescending)
            {
                model = model.OrderByDescending(o => o.ID).ToList();
            }
            return model;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await _Context.Tbl_Products.Where(p => p.ID.Equals(id)).SingleOrDefaultAsync();
            return product;
        }
    }
}
