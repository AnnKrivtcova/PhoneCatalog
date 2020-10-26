using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneCatalog.Models.Db;
using PhoneCatalog.Services;

namespace PhoneCatalog.Controllers
{
    public class SubscriberController : ApiController
    {
        SubscriberService service = new SubscriberService();

        [HttpPost]
        public HttpResponseMessage Insert(string Surname, string FirstName, string MiddleName, string Phone)
        {
            service.InsertSubscriber(Surname, FirstName, MiddleName, Phone);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpGet]
        public HttpResponseMessage Browse()
        {
            service.BrowseAllSubscribers();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage DeleteById(int Id)
        {
            service.DeleteSubscriberById(Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage UpdateById(int Id, DateTime BDay, string Surname = null, string FirstName = null, string MiddleName = null, string Phone = null)
        {
            service.UpdateSubscriberById(Id, Surname, FirstName, MiddleName, BDay, Phone);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
