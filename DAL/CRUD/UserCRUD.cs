using System.Collections.Generic;
using System.IO;
using System.Linq;
using Honey.Common;
using Honey.DAL.Entity;
using LINQtoCSV;

namespace Honey.DAL.CRUD
{
    public class UserCRUD : CRUD<User>
    {
        public UserCRUD() : base() { }

        public override int GetNextNumber()
        {
            return 0;
        }

        public override List<User> GetList()
        {
            CsvContext cc = new CsvContext();
            List<User> admins = cc.Read<User>(FileName).ToList();
            return admins;
        }

        public override User Get(int id)
        {
            return default(User);
        }

        public override int Add(User item)
        {
            return 0;
        }

        public override void Update(User item) { }

        public override void Delete(int id) { }

        public User Login(string userName, string password)
        {
            List<User> admins = GetList();
            User admin = admins.Where(x => x.UserName.Equals(userName) && x.Password.Equals(password) && x.IsActive).FirstOrDefault();
            return admin;
        }
    }
}
