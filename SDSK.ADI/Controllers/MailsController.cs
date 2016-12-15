using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDSK.API.Model;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {

        //GET /api/mails
        public IEnumerable<Mail> Get()
        {
            return Data.Mails;
        }


        //GET /api/mails/{id}
        public Mail Get(long id)
        {
            var mail = Data.Mails.SingleOrDefault(x => x.Id == id);
            if (mail != null)
                return mail;
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        //POST /api/mails
        public void Post([FromBody]Mail mail)
        {
            if (mail != null && ModelState.IsValid)
            {
                Data.Mails.Add(mail);
            }
            else
            {
                var message = "invalid input mail";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
            }
        }


        //PUT /api/mails/{id}
        public void Put(long id, [FromBody]Mail mail)
        {
            if (mail != null && ModelState.IsValid)
            {
                var mailToUpdate = Data.Mails.SingleOrDefault(x => x.Id == id);
                if (mailToUpdate != null)
                {
                    Data.Mails.Remove(mailToUpdate);
                    Data.Mails.Add(mail);
                }
                else
                {
                    var message = $"Mail with id = {id} not found";
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
                }
            }
            else
            {
                var message = "Invalid input mail";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
            }
        }


        //DELETER /api/mails/{id}
        public void Delete(long id)
        {
            var mail = Data.Mails.SingleOrDefault(x => x.Id == id);
            if (mail != null)
            {
                Data.Mails.Remove(mail);
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

    }
}