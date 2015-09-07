using System.Collections.Generic;
using System.Linq;
using Honey.DAL.Entity;
using LINQtoCSV;
using System.IO;

namespace Honey.DAL.CRUD
{
    public class PostingCRUD : CRUD<Posting>
    {
        public PostingCRUD() : base() { }

        public override List<Posting> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Posting> postings = cc.Read<Posting>(FileName).ToList();
            return postings;
        }

        public override Posting Get(int id)
        {
            return default(Posting);
        }

        public override int Add(Posting item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Posting> postings = GetList();
            if (postings == null)
            {
                // Create list
                postings = new List<Posting>();
            }

            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            // Add item
            postings.Add(item);
            // Write
            cc.Write(postings, FileName);
            // Return item id
            return item.Id;           
        }


        public override void Update(Posting item)
        {
            CsvContext cc = new CsvContext();
            List<Posting> postings = GetList();
            int index = GetList()
            .FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
                postings[index].Description = item.Description;
                postings[index].UserName = item.UserName;
                postings[index].Show = item.Show;
                cc.Write(postings, FileName);
            }           
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
            List<Posting> postings = GetList();
            if (postings == null)
            {
                // TODO: Fail
                return;
            }
            // Search item by id
            Posting posting = postings.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (posting == null || !posting.Id.Equals(id))
            {
                // TODO: Fail
                return;
            }
            // Delete item
            postings.Remove(posting);
            // Write
            cc.Write(postings, FileName);
        }

       
    }
}
