using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honey.DAL.Entity;
using LINQtoCSV;

namespace Honey.DAL.CRUD
{
    public class TopicCRUD : CRUD<Topic>
    {
        public TopicCRUD() : base() { }

        public override List<Topic> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Topic> Topics = cc.Read<Topic>(FileName).ToList();
            return Topics;
        }

        public override Topic Get(int id)
        {
            return default(Topic);
        }

        public override int Add(Topic item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Topic> Topics = GetList();
            if (Topics == null)
            {
                // Create list
                Topics = new List<Topic>();
            }

            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            // Add item
            Topics.Add(item);
            // Write
            cc.Write(Topics, FileName);
            // Return item id
            return item.Id;
        }


        public override void Update(Topic item)
        {
            CsvContext cc = new CsvContext();
            List<Topic> Topics = GetList();
            int index = GetList()
            .FindIndex(x => x.Id == item.Id);
            if (index != 0)
            {
                Topics[index].Code = item.Code;
                Topics[index].Content = item.Content;
            }
            cc.Write(Topics, FileName);
        }

        public override void Delete(int id) { }

    }
}
