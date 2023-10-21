using ShopExample.Model.Model;
using ShopExample.Services;
using ShopExample.Web.Mapping;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopExample.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;

        public HomeController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();

            var mapper = AutoMapperConfiguration.Configure();
            var listProductCategory = mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>> (model);

            return PartialView(listProductCategory);
        }
    }
}