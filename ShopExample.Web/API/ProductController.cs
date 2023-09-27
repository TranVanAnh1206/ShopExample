using ShopExample.Data.Infrastructure;
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
using ShopExample.Web.Infrastructure.Extensions;

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
        public async Task<HttpResponseMessage> GetAll(HttpRequestMessage requestMessage)
        {
            return await Task.Run(() =>
            {
                return CreatedHttpResponseAsync(requestMessage, async () =>
                {
                    var list = await _productService.GetAllAsync();

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<List<ProductViewModel>>(list);

                    var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                    return response;
                });
            });
        }

        [Route("addnew")]
        public HttpResponseMessage Add(HttpRequestMessage requestMessage, ProductViewModel pvm)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                try
                {
                    if (!ModelState.IsValid)
                    {
                        response = requestMessage.CreateResponse(HttpStatusCode.NoContent, ModelState);
                    }
                    else
                    {
                        try
                        {
                            var newProduct = new Product();
                            newProduct.UpdateProduct(pvm);
                            newProduct.CreatedDate = DateTime.Now;
                            newProduct.CreatedBy = "Admin";

                            _productService.Add(newProduct);
                            _productService.SaveChanged();

                            var mapper = AutoMapperConfiguration.Configure();
                            var responseData = mapper.Map<Product, ProductViewModel>(newProduct);

                            response = requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                        } catch (Exception ex)
                        {
                            response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

                        }
                    }
                }
                catch (Exception ex)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return response;
            });
        }
    }
}