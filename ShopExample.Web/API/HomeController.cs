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
    [Authorize]
    [RoutePrefix("api/home")]
    public class HomeController : BaseAPIController
    {
        IErrorService _errorService;

        public HomeController(IErrorService errorService) : base (errorService)
        {
            this._errorService = errorService;
        }

        [Authorize]
        [Route("TestMethod")]
        [HttpGet]
        public string TestMethod()
        {
            return "Hello, Welcom back, Login is successfully.";
        }

    }
}
