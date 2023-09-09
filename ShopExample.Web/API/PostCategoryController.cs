using ShopExample.Model.Model;
using ShopExample.Services;
using ShopExample.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopExample.Web.API
{

    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : API_BaseController
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                HttpResponseMessage response = requestMessage.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }

        // GET api/<controller>
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, PostCategory postCategory)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.Created, category);
                }

                return response;
            });
        }

        // PUT api/<controller>/5
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, PostCategory postCategory)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.SaveChanged();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        // DELETE api/<controller>/5
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, long id)
        {
            return CreatedHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
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