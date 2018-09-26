using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace ObjectRename
{
    [TableName("UserInfo")]
    [PrimaryKey("UID")]
    [ExplicitColumns]
    public class UserInfo
    {
        [Column]
        public int UID { set; get; }

        [Column]
        public string UName { set; get; }

        [Column]
        public DateTime? UDate { set; get; }
    }
}
