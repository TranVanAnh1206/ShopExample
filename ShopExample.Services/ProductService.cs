using ShopExample.Common.Common;
using ShopExample.Common.Helper;
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

    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        IProductTagRepository _productTagRepository;
        ITagRepository _tagRepository;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }

        public Product Add(Product product)
        {
            var newProduct = _productRepository.Add(product);
            _unitOfWork.Commit();

            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tagList = product.Tags.Split(',');

                for (int i=0; i<tagList.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tagList[i]);

                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = tagList[i];
                        tag.Type = CommonConstants.productTag;
                        _tagRepository.Add(tag);
                        _unitOfWork.Commit();
                    }

                    ProductTag prodTag = new ProductTag();
                    prodTag.TagID = tagID;
                    prodTag.ProductID = newProduct.ID;
                    _productTagRepository.Add(prodTag);
                    _unitOfWork.Commit();
                }

            }

            return newProduct;
        }

        public IEnumerable<Product> GetBestSellProduct()
        {
            return _productRepository.GetBestSellProduct();
        }

        public Product Delete(Guid id)
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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string keyword)
        {
            if (!string.IsNullOrEmpty (keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return await _productRepository.GetAllAsync();
            }
        }

        public IEnumerable<Product> GetAllByCategoryID(Guid categID)
        {
            return _productRepository.GetMulti(x => x.CategoryID == categID);
        }

        public Product GetByID(Guid id)
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

            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tagList = product.Tags.Split(',');
                
                for (int i=0; i<tagList.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tagList[i]);

                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        var tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = tagList[i];
                        _tagRepository.Add(tag);
                        _unitOfWork.Commit();
                    }

                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
                    var productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagID;
                    _unitOfWork.Commit();
                }
            }
        }
    }
}
