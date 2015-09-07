using System.Collections.Generic;
using System.Linq;
using Honey.DAL.Entity;
using LINQtoCSV;

namespace Honey.DAL.CRUD
{
    public class RecipientCRUD: CRUD<Recipient>
    {
        public RecipientCRUD() : base() { }

        /// <summary>
        /// Gets recipients list
        /// </summary>
        /// <returns></returns>
        public override List<Recipient> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Recipient> recipients = cc.Read<Recipient>(FileName).ToList();
            return recipients;
        }

        public override int Add(Recipient item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Recipient> recipients = GetList();
            if (recipients == null)
            {
                // Create list
                recipients = new List<Recipient>();
            }
            
            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            // Add item
            recipients.Add(item);
            // Write
            cc.Write(recipients, FileName);
            // Return item id
            return item.Id;
        }

        public override void Update(Recipient item)
        {
            if (item == null)
            {
                // TODO: Fail
                return;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Recipient> recipients = GetList();
            if (recipients == null)
            {
                // TODO: Fail
                return;
            }

            bool updated = false;

            // Search item by id
            foreach (Recipient recipient in recipients)
            {
                if (recipient.Id.Equals(item.Id))
                {
                    // Update item
                    recipient.EmailAddress = item.EmailAddress;
                    recipient.IsValid = item.IsValid;
                    recipient.IsActive = item.IsActive;
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
            cc.Write(recipients, FileName);
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
            List<Recipient> recipients = GetList();
            if (recipients == null)
            {
                // TODO: Fail
                return;
            }
            // Search item by id
            Recipient recipient = recipients.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (recipient == null || !recipient.Id.Equals(id))
            {
                // TODO: Fail
                return;
            }
            // Delete item
            recipients.Remove(recipient);
            // Write
            cc.Write(recipients, FileName);
        }
    }
}
