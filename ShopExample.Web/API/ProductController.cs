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
using System.Web.Script.Serialization;

namespace ShopExample.Web.API
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController : API_BaseController
    {
        IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, long id)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                try
                {
                    var product = _productService.GetByID(id);

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<Product, ProductViewModel>(product);

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                }
                catch (Exception ex)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return response;
            });
        }

        [Route("getall")]
        public async Task<HttpResponseMessage> GetAll(HttpRequestMessage requestMessage, string searchKeyword, int page, int pageSize = 5)
        {
            return await Task.Run(() =>
            {
                return CreatedHttpResponseAsync(requestMessage, async () =>
                {
                    var list = await _productService.GetAllAsync(searchKeyword);

                    var query = list.OrderByDescending(x => x.CreatedDate).Skip((page) * pageSize).Take(pageSize);

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<List<ProductViewModel>>(query);


                    int totalRow = list.Count();

                    var pagination = new PaginationSet<ProductViewModel>()
                    {
                        Items = responseData,
                        TotalCount = totalRow,
                        TotalPage = (int) Math.Ceiling((double) totalRow / (double) pageSize),
                        Page = page

                    };

                    var response = requestMessage.CreateResponse(HttpStatusCode.OK, pagination);

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
                            newProduct.CreatedBy = User.Identity.Name;

                            _productService.Add(newProduct);
                            _productService.SaveChanged();

                            var mapper = AutoMapperConfiguration.Configure();
                            var responseData = mapper.Map<Product, ProductViewModel>(newProduct);

                            response = requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                        }
                        catch (Exception ex)
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

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, ProductViewModel pvm)
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
                            var product = _productService.GetByID(pvm.ID);
                            product.UpdateProduct(pvm);
                            product.ModifiedDate = DateTime.Now;
                            product.ModifiedBy = User.Identity.Name;

                            _productService.Update(product);
                            _productService.SaveChanged();

                            var mapper = AutoMapperConfiguration.Configure();
                            var responseData = mapper.Map<Product, ProductViewModel>(product);

                            response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                        }
                        catch (Exception ex)
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

        [HttpDelete]
        [Route("deleteMultiple")]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, string productCheckedJSON)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                try
                {
                    var listProduct = new JavaScriptSerializer().Deserialize<List<Product>>(productCheckedJSON);

                    foreach (var item in listProduct)
                    {
                        _productService.Delete(item.ID);
                    }

                    _productService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, listProduct.Count());


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