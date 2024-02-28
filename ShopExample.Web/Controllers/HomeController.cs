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
        IFooterService _footerService;

        public HomeController(IProductCategoryService productCategoryService, IFooterService footerService)
        {
            _productCategoryService = productCategoryService;
            _footerService = footerService;
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
            var footerModel = _footerService.GetFooter();
            var mapper = AutoMapperConfiguration.Configure();
            var footerViewModel = mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
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