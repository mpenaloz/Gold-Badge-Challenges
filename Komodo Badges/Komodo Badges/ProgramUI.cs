using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Badges
{
    public class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedMethod();
            UI();
        }

        private void UI()
        {
            bool isRunning = true;
            while (isRunning)
            {
                System.Console.WriteLine("What would you like to do?" +
                    "\n1. Add a badge" +
                    "\n2. Edit a badge" +
                    "\n3. List all badges" +
                    "\n4. Exit Program");
                string userResponse = System.Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        NewBadge();
                        break;

                    case "2":
                        UpdateDoor();
                        break;

                    case "3":
                        ViewBadges();
                        break;

                    case "4":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        
        private void DisplayBadges(Badge badge)
        {
            Console.WriteLine("Badge # \tDoorAccess");
            Console.Write(badge.BadgeID + "\t\t" );
            foreach (var door in badge.Doors)
            {
                Console.Write(door);
            }
        }
        private void ViewBadges()
        {
            Console.Clear();

            var listOfBadges = _badgeRepo.GetBadgeList();

            foreach (var badge in listOfBadges)
            {
                DisplayBadges(badge.Value);
            }

        }
        private void NewBadge()
        {
            Console.Clear();
            Badge newbadge = new Badge();

            Console.WriteLine("What is the number on the badge: ");
            int num = Convert.ToInt32(Console.ReadLine());
            newbadge.BadgeID = num;
            _badgeRepo.AddBadgeToList(newbadge);

            Console.WriteLine("List a door that it needs access to: ");
            string input = (Console.ReadLine());
            _badgeRepo.AddDoorToList(num, input);

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("Would you like to add another door? (y/n)");
                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine("List a door that it needs access to: ");
                    string inputTwo = (Console.ReadLine());
                    _badgeRepo.AddDoorToList(num, inputTwo);
                }
                else
                {
                    addingDoors = false;
                }
            }
           
        }
        private void SeedMethod()
        {
            List<string> strings = new List<string>();
            strings.Add("A12");

            var BadgeA = new Badge(strings);
            _badgeRepo.AddBadgeToList(BadgeA);
        }
        private bool UpdateDoor()
        {
            Console.Clear();

            Console.WriteLine("What is the badge number to update? ");
            int input = Convert.ToInt32(Console.ReadLine());

            Badge searched = _badgeRepo.GetBadgeByID(input);

            Console.Write("Badge# " + searched.BadgeID + " Has access to");
            foreach (var door in searched.Doors)
            {
                Console.Write(door+",");
            }

            Console.WriteLine();

            Console.WriteLine("What would you like to do? \n"
                +"1.Remove a door\n"
                +"2.Add a door\n");
            int data = Convert.ToInt32(Console.ReadLine());

            if (data == 1)
            {
                Console.WriteLine("What door would you like to remove? ");
                string doorNum = Console.ReadLine();
                var gone = _badgeRepo.RemoveDoor(searched.BadgeID, doorNum);
                return true;
            }
            else if (data == 2)
            {
                Console.WriteLine("What door would you like to add? ");
                string doorAdd = Console.ReadLine();
                var added = _badgeRepo.AddDoorToList(searched.BadgeID, doorAdd);

                return true;
            }
            else
            {
                ;
                return false;
            }
           
            
        }
      
    }
}
        
    

