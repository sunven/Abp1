using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;

namespace AuditingWebApiDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            Thread.Sleep(new Random().Next(500, 1000));
            return new[] { "Get" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            Thread.Sleep(new Random().Next(500, 1000));
            return id + "";
        }

        [Route("api/values/GetError")]
        public void GetError()
        {
            var a = Convert.ToInt32("a");
        }
    }
}
