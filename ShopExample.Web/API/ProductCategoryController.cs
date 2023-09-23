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
using System.Threading;
using System.Web.Script.Serialization;

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

        [Route("getbyid/{id:long}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage requestMessage, long id)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var listPC = _productCategoryService.GetById(id);

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(listPC);

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                var listPC = _productCategoryService.GetAll();

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<List<ProductCategoryViewModel>>(listPC);

                response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage, string keyword, int page = 1, int pageSize = 20)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var listPC = _productCategoryService.GetAll(keyword);
                int totalRow = listPC.Count();
                var query = listPC.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);

                var mapper = AutoMapperConfiguration.Configure();
                var responseData = mapper.Map<List<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPage = (int)Math.Ceiling((double)totalRow / pageSize)
                };

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Add (HttpRequestMessage requestMessage, ProductCategoryViewModel pcVM)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCateg = new ProductCategory();
                    newProductCateg.UpdateProductCategory(pcVM);
                    newProductCateg.CreatedDate = DateTime.Now;
                    newProductCateg.CreatedBy = "";

                    _productCategoryService.Add(newProductCateg);
                    _productCategoryService.SaveChanged();

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCateg);
                    response = requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage requestMessage, ProductCategoryViewModel pcVM)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(pcVM.ID);
                    dbProductCategory.UpdateProductCategory(pcVM);
                    dbProductCategory.ModifiedDate = DateTime.Now;
                    dbProductCategory.ModifiedBy = "";

                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.SaveChanged(); 

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete (HttpRequestMessage requestMessage, int id)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProdCategory = _productCategoryService.Delete(id);
                    _productCategoryService.SaveChanged();

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProdCategory);

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });

        }

        [HttpDelete]
        [Route("deletemulti")]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti (HttpRequestMessage requestMessage, string checkedProductCategoryJson)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<ProductCategory>>(checkedProductCategoryJson);

                    foreach (var item in listProductCategory)
                    {
                        _productCategoryService.Delete(item.ID);
                    }

                    _productCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }

                return response;
            });
        }

    }
}