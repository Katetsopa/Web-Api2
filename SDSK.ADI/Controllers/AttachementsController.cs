﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDSK.API.Model;

namespace SDSK.API.Controllers
{
    [RoutePrefix("api/mails/{id}/attachments")]
    public class AttachementsController : ApiController
    {

        //GET api/mails/{id}/attachements/{attId}
        [Route]
        public IEnumerable<Attachement> Get(long id, int attId)
        {
            if (Data.Mails.Exists(x => x.Id == id))
            {
                if (Data.AttList.Where(x => x.MailId == id).Where(c => c.Id == attId).Any())
                {
                    return Data.AttList.Where(x => x.MailId == id).Where(c => c.Id == attId);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        $"Mail with id = {id} don't have any attachments with id = {attId}"));
                }
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        //GET api/mails/{id}/attachements/extention = { ext }
        //GET api/mails/{id}/attachements/extention = { ext }? status = { status }
        [Route]
        public IEnumerable<Attachement> Get(long id, string ext = null, int status = 0)
        {
            if (Data.Mails.Exists(x => x.Id == id))
            {
                IEnumerable<Attachement> result = Data.AttList.Where(x => x.MailId == id);
                if (ext != null)
                    result = result.Where(x => x.FileExtention == ext);
                if (status != 0)
                    result = result.Where(x => x.StatusId == status);
                return result;
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        //PUT api/mails/{id}/attachements/{attId}
        [Route]
        public void Put(long id, int attId, [FromBody]Attachement attach)
        {
            if (Data.Mails.Exists(x => x.Id == id))
            {
                var attachToUpdate = Data.AttList.Where(x => x.MailId == id).SingleOrDefault(c => c.Id == attId);
                if (attachToUpdate == null)
                {
                    var message = $"Attachment with id = {attId} don't exist";
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
                }
                else
                {
                    Data.AttList.Remove(attachToUpdate);
                    Data.AttList.Add(attach);
                }
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        //POST api/mails/{id}/attachements
        [Route]
        public void Post(long id, [FromBody]Attachement attachement)
        {
            if (Data.Mails.Exists(x => x.Id == id))
            {
                if (attachement != null && ModelState.IsValid)
                {
                    Data.AttList.Add(attachement);
                }
                else
                {
                    var message = "invalid input attachment";
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
                }
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }


        //DELETE api/mails/{id}/attachements/{attId}
        [Route]
        public void Delete(long id, int attId)
        {
            if (Data.Mails.Exists(x => x.Id == id))
            {
                var attach = Data.AttList.Where(x => x.MailId == id).SingleOrDefault(c => c.Id == attId);
                if (attach != null && ModelState.IsValid)
                {
                    Data.AttList.Remove(attach);
                }
                else
                {
                    var message = $"Attachment with id = {attId} don't exist";
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
                }
            }
            else
            {
                var message = $"Mail with id = {id} not found";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
        }

    }
}
