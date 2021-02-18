using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repo
{
    public class BadgesClass
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }

        public BadgesClass(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        public BadgesClass()
        {
        }
    }
}
