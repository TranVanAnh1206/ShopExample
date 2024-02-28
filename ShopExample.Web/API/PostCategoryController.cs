using AutoMapper;
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
using System.Web.Http;
using ShopExample.Web.Infrastructure.Extensions;

namespace ShopExample.Web.API
{

    [Authorize]
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : BaseAPIController
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                var mapper = AutoMapperConfiguration.Configure();

                var listPostCategoryVm = mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = requestMessage.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);

                return response;
            });
        }

        // GET api/<controller>
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVM)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVM);
                    postCategory.CreatedDate = DateTime.Now;
                    postCategory.CreatedBy = User.Identity.Name;

                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.Created, category);
                }

                return response;
            });
        }

        // PUT api/<controller>/5
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVM)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVM);
                    postCategoryDb.ModifiedDate = DateTime.Now;
                    postCategoryDb.ModifiedBy = User.Identity.Name;

                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        // DELETE api/<controller>/5
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, Guid id)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}