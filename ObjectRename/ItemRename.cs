using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRename
{
    public class ItemRename
    {
        public void Test()
        {
            List<string> users = new List<string>() { "A", "B", "C", "D", "A", "A" };
            //Console.WriteLine(users.Count);
            //users.ForEach(Console.WriteLine);

            Console.WriteLine("................");
            List<string> users2 = new List<string>();

            for (int i = 0; i < users.Count; i++)
            {
                int num = 0;
                foreach (var user in users.GetRange(0, i + 1))
                {
                    if (user == users[i])
                    {
                        num++;
                    }
                }

                //users[i] = users[i] + (num == 0 ? "" : num.ToString());

                //Console.WriteLine($"{users[i]}-{num}");
                users2.Add(users[i] + (num == 1 ? "" : num.ToString()));
            }

            foreach (var u in users2)
            {
                Console.WriteLine(u);
            }
        }
    }
}
