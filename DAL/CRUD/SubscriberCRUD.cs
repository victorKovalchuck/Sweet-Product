using System.Collections.Generic;
using System.Linq;
using Honey.DAL.Entity;
using LINQtoCSV;
using System;


namespace Honey.DAL.CRUD
{
    public class SubscriberCRUD : CRUD<Subscriber>
    {
        public SubscriberCRUD() : base() { }

        /// <summary>
        /// Gets recipients list
        /// </summary>
        /// <returns></returns>
        public override List<Subscriber> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Subscriber> subscribers = cc.Read<Subscriber>(FileName).ToList();

            return subscribers;
        }

        public override int Add(Subscriber item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Subscriber> subscribers = GetList();
            if (subscribers == null)
            {
                // Create list
                subscribers = new List<Subscriber>();
            }

            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            // Add item
            subscribers.Add(item);
            // Write
            cc.Write(subscribers, FileName);
            // Return item id
            return item.Id;
        }

        public override void Update(Subscriber item)
        {
            if (item == null)
            {
                // TODO: Fail
                return;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Subscriber> subscribers = GetList();
            if (subscribers == null)
            {
                // TODO: Fail
                return;
            }

            bool updated = false;

            // Search item by id
            foreach (Subscriber subscriber in subscribers)
            {
                if (subscriber.Id.Equals(item.Id))
                {
                    // Update item                    
                    subscriber.EmailAddress = item.EmailAddress;
                    subscriber.IsActive = item.IsActive;
                    subscriber.CreatedAt = item.CreatedAt;
                    subscriber.UpdatedAt = item.UpdatedAt;
                    updated = true;
                    break;
                }
            }
            if (!updated)
            {
                // TODO: Fail
                return;
            }

            // Write
            cc.Write(subscribers, FileName);
        }
        
        public void UpdateByEmail(string email)
        {
            if (email == "")
            {
                return;
            }

            CsvContext cc = new CsvContext();
            List<Subscriber> subscribers = GetList();
            if (subscribers == null)
            {
                return;
            }

            bool updated = false;

            foreach (Subscriber subscriber in subscribers)
            {
                if (subscriber.EmailAddress.Contains(email))
                {
                    subscriber.UpdatedAt = DateTime.Now;
                    updated = true;
                    break;
                }
            }
            if (!updated)
            {             
                return;
            }           
            cc.Write(subscribers, FileName);
        }

        public override void Delete(int id)
        {
            if (id == 0)
            {
                // TODO: Fail
                return;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Subscriber> subscribers = GetList();
            if (subscribers == null)
            {
                // TODO: Fail
                return;
            }
            // Search item by id

            Subscriber subscrible = subscribers.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (subscrible == null || !subscrible.Id.Equals(id))
            {
                // TODO: Fail
                return;
            }           
            // Delete item
            subscribers.Remove(subscrible);
            // Write
            cc.Write(subscribers, FileName);
        }
    }
}
