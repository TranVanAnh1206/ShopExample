using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{
    public interface IProductService
    {
        Product Add(Product product);
        Product Delete(Guid id);
        void Update(Product product);
        IEnumerable<Product> GetAll();
        Task<IEnumerable<Product>> GetAllAsync();
        IEnumerable<Product> GetBestSellProduct();
        IEnumerable<Product> GetAll(string keyword);
        Task<IEnumerable<Product>> GetAllAsync(string keyword);
        Product GetByID(Guid id);
        IEnumerable<Product> GetAllByCategoryID(Guid categID);
        void SaveChanged();
    }
}
