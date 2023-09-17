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
    public interface IProductService
    {
        Product Add(Product product);
        Product Delete(long id);
        void Update(Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        Product GetByID(long id);
        IEnumerable<Product> GetAllByCategoryID(long categID);
        void SaveChanged();
    }

    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;


        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Delete(long id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productRepository.GetAll();
            }
        }

        public IEnumerable<Product> GetAllByCategoryID(long categID)
        {
            return _productRepository.GetMulti(x => x.CategoryID == categID);
        }

        public Product GetByID(long id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
