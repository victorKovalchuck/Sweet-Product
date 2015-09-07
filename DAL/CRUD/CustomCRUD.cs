using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honey.DAL.Entity;
using LINQtoCSV;


namespace Honey.DAL.CRUD
{
    public class CustomCRUD : CRUD<Custom>
    {
        public CustomCRUD() : base() { }

        public override List<Custom> GetList()
        {
            CsvContext cc = new CsvContext();
            List<Custom> Customs = cc.Read<Custom>(FileName).ToList();
            return Customs;
        }

        public override Custom Get(int id)
        {
            return default(Custom);
        }

        public override int Add(Custom item)
        {
            if (item == null)
            {
                // TODO: Fail
                return 0;
            }

            CsvContext cc = new CsvContext();
            // Get existing list
            List<Custom> Customs = GetList();
            if (Customs == null)
            {
                // Create list
                Customs = new List<Custom>();
            }

            // Get next id
            int nextId = GetNextNumber();
            // Set next id
            item.Id = nextId;

            // Add item
            Customs.Add(item);
            // Write
            cc.Write(Customs, FileName);
            // Return item id
            return item.Id;
        }


        public override void Update(Custom item)
        {
            CsvContext cc = new CsvContext();
            List<Custom> Customs = GetList();
            int index = GetList()
            .FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
            
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
            List<Custom> Customs = GetList();
            if (Customs == null)
            {
                // TODO: Fail
                return;
            }
            // Search item by id
            Custom Custom = Customs.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (Custom == null || !Custom.Id.Equals(id))
            {
                // TODO: Fail
                return;
            }
            // Delete item
            Customs.Remove(Custom);
            // Write
            cc.Write(Customs, FileName);
        }

    }
}
