using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Badges
{
    public class BadgeRepo
    {
        private Dictionary<int,Badge> _listOfBadges = new Dictionary<int, Badge>();
        private int _count;
        public bool AddBadgeToList(Badge badge)
        {
            if (badge == null)
            {
                return false;
            }
            _count++;
            badge.BadgeID = _count;
            _listOfBadges.Add(badge.BadgeID, badge);
            return true;
        }

        public Dictionary<int, Badge> GetBadgeList()
        {
            return _listOfBadges;
        }
    
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (var badge in _listOfBadges)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }
            }
            return null;
        }

        public bool RemoveDoor(int badgeID, string doorName)
        {
            var badge = GetBadgeByID(badgeID);

            if (badge == null)
            {
                return false;
            }
            foreach (var door in badge.Doors)
            {
                if (door == doorName)
                {
                    badge.Doors.Remove(door);
                    return true;
                }
                
            }
            return false;
        }

        public bool AddDoorToList(int badgeID, string doorName)
        {
            var badge = GetBadgeByID(badgeID);
            if (badge == null)
            {
                return false;
            }
            badge.Doors.Add(doorName);
            return true; ;
        }
    }
}
