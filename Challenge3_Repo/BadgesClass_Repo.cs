using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repo
{
    public class BadgesClass_Repo
    {
        private Dictionary<int, List<string>> _doors = new Dictionary<int, List<string>>();
        private readonly List<BadgesClass> _doorBadges = new List<BadgesClass>();
        public int Count
        {
            get
            {
                return _doorBadges.Count;
            }
        }    
        
        public Dictionary<int, List<string>> ViewAllBadges()
        {
            return _doors;
        }
        public void AddToNewBadges(BadgesClass badges)
        {
           // int startingCount = _doors.Count;
           // _doorBadges.Add(new BadgesClass(BadgeID, Doors));

           // bool wasAdded = _doors.Count > startingCount;
           // return wasAdded;
            _doorBadges.Add(badges);
        }
        public bool UpdateAccessToDoorsFromBadgeID(int originalBadgeID, BadgesClass newDoorAccess)
        {
            BadgesClass oldDoorAcess = GetDoorAccessThroughID(originalBadgeID);

            if (oldDoorAcess != null)
            {
                oldDoorAcess.BadgeID = newDoorAccess.BadgeID;
                oldDoorAcess.Doors = newDoorAccess.Doors;

                return true;
            }
            return false;
        }

        public BadgesClass GetDoorAccessThroughID(int id)
        {
            foreach (BadgesClass badges in _doorBadges)
            {
                if (badges.BadgeID == id)
                {
                    return badges;
                }
            }
            return null;
        }
        public bool RemoveDoorFromBadgeID(int id)
        {
            BadgesClass doorToDelete = GetDoorAccessThroughID(id);
            return _doorBadges.Remove(doorToDelete);
        }
    }
}
