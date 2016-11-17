using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDSK.API.Model;

namespace SDSK.API.Controllers
{
    public class JiraItemsController : ApiController
    {     
        //GET api/jiraitems/{id}
        public JiraItem Get(int id = 1)
        {
            var jiraItem = Data.JiraItems.SingleOrDefault(x => x.JiraItemId == id);
            if (jiraItem != null)
            {
                return jiraItem;
            }
            else
            {
                var message = $"JiraItem with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

        // POST: api/JiraItems
        public void Post([FromBody]string value)
        {
            
        }

        // PUT: api/JiraItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JiraItems/5
        public void Delete(int id)
        {
        }
    }
}
