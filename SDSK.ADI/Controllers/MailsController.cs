using SDSK.API.Model;
using System.Web.Http;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {
        //GET /api/mails
        [HttpGet]
        public Mail Get()
        {
            return new Mail() {Id =1 , Body = "mail", Priority = Priority.Low};
        }

        //GET /api/mails/{id}
        //PUT /api/mails/{id}
        //POST /api/mails
        //DELETER /api/mails/{id}
    }
}
