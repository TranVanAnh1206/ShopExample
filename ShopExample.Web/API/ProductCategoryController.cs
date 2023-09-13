using ShopExample.Model.Model;
using ShopExample.Services;
using ShopExample.Web.Infrastructure.Core;
using ShopExample.Web.Mapping;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShopExample.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : API_BaseController
    {
        IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage )
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var listPC = _productCategoryService.GetAll();

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<List<ProductCategoryViewModel>>(listPC);

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

    }
}