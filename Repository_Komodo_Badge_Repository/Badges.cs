using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_Badge_Repository
{
    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> ListOfDoors { get; set; }
        
        public Badges() { }

        public Badges(int badgeId, List<string> listOfDoors)
        {
            BadgeId = badgeId;
            ListOfDoors = ListOfDoors;
        }

    }
}
