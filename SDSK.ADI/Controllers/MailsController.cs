using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SDSK.API.Model;
using SDSK.API.Models;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {
        //static list of 

        //GET /api/mails
        //GET /api/mails/{id}
        //PUT /api/mails/{id}
        //POST /api/mails
        //DELETER /api/mails/{id}

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mails/5
        public void Delete(int id)
        {
        }

    }
}