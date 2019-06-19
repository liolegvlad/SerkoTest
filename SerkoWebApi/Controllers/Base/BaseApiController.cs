using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerkoWebApi.Controllers.Base
{
    public class BaseApiController : ApiController
    {
        protected string GetObjectFromRequest()
        {
            var requestContent = Request.Content;
            return requestContent.ReadAsStringAsync().Result;
        }
    }
}