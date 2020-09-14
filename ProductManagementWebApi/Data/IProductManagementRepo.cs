using ProductManagementWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementWebApi.Data
{
    public interface IProductManagementRepo
    {

        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task PutProductAsync(Product product);
        Task<Product> AddAsync(Product product);
        Task DeleteProductAsync(int id);
        bool ProductExists(int id);
     
    }
}
