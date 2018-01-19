using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuditingWebApiDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var a = 0;
            for (var i = 0; i < 10000; i++)
                for (var j = 0; j < 10000; j++)
                    a = i - j;
            return new[] { a + "", };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var a = 0;
            for (var i = 0; i < 10000; i++)
                for (var j = 0; j < 10000; j++)
                    a = i - j;
            return a + "";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
