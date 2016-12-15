using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDSK.API.Model;

namespace SDSK.API.Controllers
{
    [RoutePrefix("api/jiraitems")]

    public class JiraItemsController : ApiController
    {
        //GET api/jiraitems/{id}
       // [Route("{id:int}")]
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

        [Route("{str}")]
        public JiraItem Get(string str)
        {
            int id;
            var isParced = int.TryParse(str, out id);
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
    }
}
