using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Badges
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors = new List<string>();

        public Badge() { }

        public Badge(List<string> doors)
        {
            Doors = doors;
        }
    }
}
