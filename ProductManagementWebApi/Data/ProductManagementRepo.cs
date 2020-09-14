using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementWebApi.Data
{
    public class ProductManagementRepo : IProductManagementRepo
    {
        private ProductManagementContext _context;

        public ProductManagementRepo(ProductManagementContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            //TODO: ToListAsync()
            return await Task.Run(() => _context.Products.ToList()).ConfigureAwait(false);
        }
        public async Task PutProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }
        public async Task<Product> AddAsync(Product product) 
        {

            await _context.Products.AddAsync(product);
            
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

    }
}
