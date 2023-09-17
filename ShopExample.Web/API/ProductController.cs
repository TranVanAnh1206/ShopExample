using ShopExample.Data.Infrastructure;
using ShopExample.Services;
using ShopExample.Web.Infrastructure.Core;
using ShopExample.Web.Mapping;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShopExample.Web.API
{
    [RoutePrefix("api/product")]
    public class ProductController : API_BaseController
    {
        IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var list = _productService.GetAll();

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<List<ProductViewModel>>(list);

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}