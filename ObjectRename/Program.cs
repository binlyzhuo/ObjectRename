using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObjectRename
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData data = new UserData();
            
            Regex regex = new Regex(@"[^0-9]+");

            var newUsers = new List<UserInfo>();
            newUsers.Add(new UserInfo(){UDate =  DateTime.Now, UName = "2018002"});
            newUsers.Add(new UserInfo(){UDate =  DateTime.Now, UName = "2018003"});
            //newUsers.Add(new UserInfo(){UDate =  DateTime.Now, UName = "张三"});

            var users = data.UsersGet();
            foreach (var info in newUsers)
            {
                bool isNumber = Regex.IsMatch(info.UName, @"^[+-]?\d*[.]?\d*$");
                if (isNumber)
                {
                    var temp2 = users.Select(mm => mm.UName == info.UName).ToList();
                    if (temp2.Count > 0)
                    {
                        Console.WriteLine("数据库有重复UName");
                        return;
                    }

                    var temp3 = newUsers.Select(mm => mm.UName == info.UName).ToList();
                    if (temp3.Count > 1)
                    {
                        Console.WriteLine("导入数据有重复UName");
                        return;
                    }
                }
                    
                
                var temp = users.Where(u => u.UName.StartsWith(info.UName)).ToList();
                int max = MaxIdGet(temp);
                if (temp.Count == 1)
                {
                    max = 1;
                }
                //int count = temp.Count;
                //Console.WriteLine(count);
                string ext = max == 0 ? "" : (max+1).ToString();
                info.UName = info.UName+ext;
                users.Add(info);
            }

            bool updateResult = data.UsersAdd(newUsers);
            Console.WriteLine(updateResult);
            Console.ReadLine();
        }

        static int MaxIdGet(List<UserInfo> users)
        {
            
            var nums = users.Select(u => Regex.Replace(u.UName, @"[^0-9]+", "")).Select(m =>
            {
                if (string.IsNullOrEmpty(m))
                    return 0;
                return Convert.ToInt32(m);

            }).ToList();
            if (nums.Count == 0)
                return 0;
            int max = nums.Max();
            return max;
        }
    }
}
