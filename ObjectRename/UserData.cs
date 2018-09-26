using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace ObjectRename
{
    public class UserData
    {
        private Database db;

        public UserData()
        {
            db = new Database("TEST");
        }

        public List<UserInfo> UsersGet()
        {
            Sql where = Sql.Builder.Where("1=1");
            var items = db.Fetch<UserInfo>(where);
            return items;
        }

        public bool UsersAdd(List<UserInfo> users)
        {
            try
            {
                db.BeginTransaction();
                foreach (var user in users)
                {
                    db.Insert(user);
                }
                db.CompleteTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
