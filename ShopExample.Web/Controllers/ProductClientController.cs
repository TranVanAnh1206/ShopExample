using Newtonsoft.Json;
using ShopExample.Model.Model;
using ShopExample.Services;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopExample.Web.Controllers
{
    public class ProductClientController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public ProductClientController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        // GET: Default
        [ChildActionOnly]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult BestSellerProduct()
        {
            var result = _productService.GetBestSellProduct();

            var mapper = Mapping.AutoMapperConfiguration.Configure();
            var productViewModel = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel> >(result);

            return PartialView(productViewModel);
        }

        [ChildActionOnly]
        public ActionResult HotProduct()
        { 
            return PartialView();
        }

        public ActionResult ProductDetail (Guid id)
        {
            var result = _productService.GetByID(id);
            var mapper = Mapping.AutoMapperConfiguration.Configure();
            var productVM = mapper.Map<Product, ProductViewModel>(result);

            string listImageProd = result.MoreImage;

            ViewBag.ImagePath = JsonConvert.DeserializeObject<List<string>>(listImageProd);
            ViewBag.Category = _productCategoryService.GetById(result.CategoryID.Value);
            ViewBag.RelateProd = _productService.GetAllByCategoryID(result.CategoryID.Value);

            return View(productVM);
        }
    }
}