using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneCatalog.Models.Db;

namespace PhoneCatalog.Services
{
    public class PhoneCatalogService
    {
        CatalogEntities phoneCatalogEntities = new CatalogEntities();

        public void InsertSubscriber(string Surname,string FirstName, string MiddleName,DateTime BDay,string Phone)
        {
            Subscriber subscriber = new Subscriber() { Surname = Surname, FirstName = FirstName, MiddleName = MiddleName, BDay = BDay, Phone = Phone };
            phoneCatalogEntities.Subscribers.Add(subscriber);
            phoneCatalogEntities.SaveChanges();
        }
        public List<Subscriber> BrowseAllSubscribers()
        {
            return phoneCatalogEntities.Subscribers.ToList();
        }
        public void DeleteSubscriberById(int Id)
        {
            var subscriber = new Subscriber(){ Id=Id};
            phoneCatalogEntities.Subscribers.Attach(subscriber);
            phoneCatalogEntities.Subscribers.Remove(subscriber);
            phoneCatalogEntities.SaveChanges();
        }
        public void UpdateSubscriberById(int Id, string Surname, string FirstName, string MiddleName, DateTime BDay, string Phone)
        {
            var subscriber = phoneCatalogEntities.Subscribers.SingleOrDefault(x => x.Id == Id);
            if (Surname != null)
                subscriber.Surname = Surname;
            if (FirstName != null)
                subscriber.FirstName = FirstName;
            if (MiddleName != null)
                subscriber.MiddleName = MiddleName;
            if (Phone != null)
                subscriber.Phone = Phone;
            phoneCatalogEntities.SaveChanges();
        }

    }
}