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
using ShopExample.Services.interfaces;

namespace ShopExample.Web.API
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController : BaseAPIController
    {
        
        IProductService _productService;
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage, Guid id)
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
                    //log.Error(ex);
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return response;
            });
        }

        /// <summary>
        /// Hàm get all product async
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("getallasync")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync(HttpRequestMessage requestMessage, string searchKeyword, int page = 0, int pageSize = 20)
        {
            return await Task.Run(() =>
            {
                return CreatedHttpResponseAsync(requestMessage, async () =>
                {
                    var list = await _productService.GetAllAsync(searchKeyword);

                    var query = list.OrderByDescending(x => x.CreatedDate).Skip((page) * pageSize).Take(pageSize);

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query.AsEnumerable());

                    int totalRow = list.Count();

                    var pagination = new PaginationSet<ProductViewModel>()
                    {
                        Items = responseData,
                        TotalCount = totalRow,
                        TotalPage = (int)Math.Ceiling((double)totalRow / (double)pageSize),
                        Page = page

                    };

                    var response = requestMessage.CreateResponse(HttpStatusCode.OK, pagination);

                    return response;
                });
            });
        }

        /// <summary>
        /// Hàm Get all product
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage, string searchKeyword, int page, int pageSize = 20)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var list = _productService.GetAll(searchKeyword);

                var query = list.OrderByDescending(x => x.CreatedDate).Skip((page) * pageSize).Take(pageSize);

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query.AsEnumerable());


                int totalRow = list.Count();

                var pagination = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((double)totalRow / (double)pageSize),
                    Page = page

                };

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });
        }

        [Route("addnew")]
        [HttpPost]
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
                            newProduct.ID = Guid.NewGuid();
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
                    //log.Error(ex);
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
                    //log.Error(ex);
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
                    var listProductID = new JavaScriptSerializer().Deserialize<List<ProductViewModel>>(productCheckedJSON);

                    foreach (var item in listProductID)
                    {
                        _productService.Delete(item.ID);
                    }

                    _productService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, listProductID.Count());
                }
                catch (Exception ex)
                {

                    //log.Error(ex);
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return response;
            });
        }
    }
}