using System;
using System.Collections.Generic;
using System.Linq;
using Honey.DAL.Entity;
using Honey.Common;
using System.IO;

namespace Honey.DAL.CRUD
{
    public class CRUD<T> where T : Base
    {
        public string FileName { get; private set; }

        public CRUD()
        {         
            FileName = DataPathHelper.GetDataPath(typeof(T).Name);
            if (!File.Exists(FileName))
            {
                FileStream filestream = new FileStream(FileName, FileMode.Create);
                filestream.Close();
            }
        }

        public virtual int GetNextNumber()
        {
            int nextNumber = 1;
            List<T> recipients = GetList();
            if (recipients != null && recipients.Count > 0)
            {
                nextNumber = recipients.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                nextNumber++;
            }
            return nextNumber;
        }

        public virtual List<T> GetList()
        {
            return null;
        }

        public virtual T Get(int id)
        {
            return default(T);
        }

        public virtual int Add(T item)
        {
            return 0;
        }

        public virtual void Update(T item) { }

        public virtual void Delete(int id) { }
    }
}
