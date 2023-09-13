using ShopExample.Data.Infrastructure;
using ShopExample.Data.Repositories;
using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory pc);
        ProductCategory Delete(long id);
        void Update(ProductCategory pc);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllByParentId(long parentId);
        ProductCategory GetById(long id);
        void SaveChanged();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory pc)
        {
            return _productCategoryRepository.Add(pc);
        }

        public ProductCategory Delete(long id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(long parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(long id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory pc)
        {
            _productCategoryRepository.Update(pc);
        }
    }
}
