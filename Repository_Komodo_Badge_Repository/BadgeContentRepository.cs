using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_Badge_Repository
{
     public class BadgeContentRepository
    {
        private List<string> listOfDoors = new List<string>();
        private Dictionary<int, Badges> BadgeDictionary = new Dictionary<int, Badges>();
        
        public void AddBadgeToDictionary(Badges badge)
        {
            BadgeDictionary.Add(badge.BadgeId, badge);
        }

        public Dictionary<int, Badges> GetBadgesDictionary()
        {
            return BadgeDictionary;
        }

        public bool UpdateExistingBadges(int originalBadgeId, Badges newBadge)
        {
            Badges oldBadge = GetBadgeById(originalBadgeId);

            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.ListOfDoors = newBadge.ListOfDoors;

                return true;
            }
            else
            {
                return false;
            }



        }
        
        public Badges GetBadgeById(int badgeId)
        {
            foreach (KeyValuePair<int, Badges> badges in BadgeDictionary)
            {
                if(badges.Key == badgeId)
                {
                    return badges.Value;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    
    }
}
