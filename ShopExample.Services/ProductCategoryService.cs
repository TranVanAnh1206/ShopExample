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

        public ProductCategory Delete(Guid id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(Guid parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status == 1 && x.ParentID == parentId);
        }

        public ProductCategory GetById(Guid id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetMany(int status)
        {
            return _productCategoryRepository.GetMany(x => x.Status == status, "");
        }

        public async Task<IEnumerable<ProductCategory>> GetManyAsync(int status)
        {
            return await _productCategoryRepository.GetManyAsync(x => x.Status == status, "");
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
