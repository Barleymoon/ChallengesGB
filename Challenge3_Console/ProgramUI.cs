using Challenge3_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Console
{
    public class ProgramUI
    {
        private Dictionary<int, List<string>> _doors = new Dictionary<int, List<string>>();
        private readonly List<BadgesClass> _doorBadges = new List<BadgesClass>();


        private readonly BadgesClass_Repo _repo = new BadgesClass_Repo();
        public void Run()
        {
            Console.ReadKey();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu\n" +
                    "Hello Security Admin,\n " +
                    "What would you like to do?\n" +
                    "" +
                    "1. Add a Badge.\n" +
                    "2. Edit a Badge.\n" +
                    "3. List all Badges\n" +
                    "4. Exit the Program.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Add a badge to dictionary
                        CreateNewBadge();
                        break;
                    case "2":
                        // Edit a badge and allow to delete all door access
                        UpdateDoorAccess();
                        break;
                    case "3":
                        // List all badges in dictionary
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number between 1-4.");
                        Console.ReadKey();
                        break;

                }
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();

            BadgesClass newbadge = new BadgesClass();

            Console.WriteLine("Please enter a Badge ID: ");
            newbadge.BadgeID = Convert.ToInt32(Console.ReadLine());
           // Console.WriteLine($"{newbadge.BadgeID} had been created");
            
            //newbadge.BadgeID = Convert.ToInt32(GetBadgeIDFromUser());

            Console.WriteLine("Please enter a door the Badge needs access to: ");
            newbadge.Doors = new List<string> {  };

            // _repo.AddToNewBadges(newbadge);
            Console.WriteLine("Are there anymore doors to add to this badge number?:\n " +
                "1. Yes\n" +
                "2. No\n" +
                "3. Return To Menu\n");
            string choose = Console.ReadLine();
            switch(choose)
            {
                case "1":
                    //Yes
                    newbadge.Doors = new List<string> { };
                    break;
                case "2":
                    _repo.AddToNewBadges(newbadge);
                    //No
                    break;
                case "3":
                    RunMenu();
                    //Menu
                    break;
                default:
                    Console.WriteLine("Please enter valid number between 1-3.");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("I'm sorry I don't have that function.");
        }
        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> listOfBadges = _repo.ViewAllBadges();
            foreach (BadgesClass badges in _doorBadges)
            {
                DisplayBadges(badges);
            }
            Console.ReadKey();
            
        }
        private void DisplayBadges(BadgesClass badges)
        {
            Console.WriteLine($"BadgeID: {badges.BadgeID}\n" +
                $"DoorAccess: {badges.Doors}\n");
        }

        private void UpdateDoorAccess()
        {
            BadgesClass badges;
            do
            {
                Console.WriteLine("What is the badge number you would like to update?");
                int badgeID = GetBadgeIDFromUser();
                badges = _repo.GetDoorAccessThroughID(badgeID);
                

            } while (badges == null);

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door.\n" +
                "2. Add a door.\n");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string oldDoorAccess = Console.ReadLine();
                    badges.Doors = new List<string>();
                    foreach (BadgesClass badge in _doorBadges)
                    {
                        if (option == "1")
                        {
                            Console.WriteLine($"{badge.Doors} was sucessfully removed from {badge.BadgeID}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that door is not available.");
                        }
                    }
                    Console.WriteLine("Please try again.");
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string newDoorAccess = Console.ReadLine();
                    badges.Doors = new List<string>();
                    foreach (BadgesClass badge in _doorBadges)
                    {
                        if (option == "2")
                        {
                            Console.WriteLine($"{badge.Doors} was succeffully added to {badge.BadgeID}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that door isnt available.");
                        }
                    }
                    Console.WriteLine("Please try again.");
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-2");
                    break;
            }
        }

        private int GetBadgeIDFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter the BadgeID: \n");
            int badgeID = Console.Read();
            return badgeID;
        }
    }
}
