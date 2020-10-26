using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PhoneCatalog.Models.Db;
using PhoneCatalog.Services;

namespace PhoneCatalog.Controllers
{
    public class PhoneCatalogController : Controller
    {
        // GET: PhoneCatalog
        PhoneCatalogService service = new PhoneCatalogService();

        [HttpGet]
        public HttpResponseMessage Insert(string Surname, string FirstName, string MiddleName, DateTime BDay, string Phone)
        {
            service.InsertSubscriber(Surname, FirstName, MiddleName, BDay, Phone);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public HttpResponseMessage Browse()
        {
            service.BrowseAllSubscribers();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public HttpResponseMessage DeleteById(int Id)
        {
            service.DeleteSubscriberById(Id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage UpdateById(int Id, DateTime BDay, string Surname=null, string FirstName=null, string MiddleName=null, string Phone = null)
        {
            service.UpdateSubscriberById(Id, Surname, FirstName, MiddleName, BDay, Phone);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}