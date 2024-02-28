using ShopExample.Data.Infrastructure;
using ShopExample.Services;
using ShopExample.Services.interfaces;
using ShopExample.Web.Infrastructure.Core;
using ShopExample.Web.Mapping;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopExample.Web.API
{
    [Authorize]
    [RoutePrefix("api/Sys_StatusAPI")]
    public class Sys_StatusAPIController : BaseAPIController
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly ISys_StatusService _sys_StatusService;

        public Sys_StatusAPIController(IErrorService errorService, ISys_StatusService sys_StatusService) : base(errorService)
        {
            _sys_StatusService = sys_StatusService;
        }

        [HttpGet()]
        [Route("GetStatusForProduct/{status_of}")]
        public async Task<HttpResponseMessage> GetStatusForProduct (HttpRequestMessage requestMessage, int status_of)
        {
            return await Task.Run(() =>
            {
                return CreatedHttpResponseAsync(requestMessage, async () =>
                {
                    var list_status = await _sys_StatusService.Get(status_of);

                    var mapper = AutoMapperConfiguration.Configure();
                    var responseData = mapper.Map<List<Sys_StatusViewModel>>(list_status);

                    var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);

                    return response;
                });
            });
        }
    }
}
