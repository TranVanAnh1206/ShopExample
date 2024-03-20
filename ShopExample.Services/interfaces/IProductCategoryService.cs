using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{

    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory pc);
        ProductCategory Delete(Guid id);
        void Update(ProductCategory pc);
        IEnumerable<ProductCategory> GetAll();
        Task<IEnumerable<ProductCategory>> GetManyAsync(int status);
        IEnumerable<ProductCategory> GetMany(int status);
        IEnumerable<ProductCategory> GetAll(string keyword);
        IEnumerable<ProductCategory> GetAllByParentId(Guid parentId);
        ProductCategory GetById(Guid id);
        void SaveChanged();
    }
}
