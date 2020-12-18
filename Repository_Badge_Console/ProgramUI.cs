using Repository_Komodo_Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Badge_Console
{
    class ProgramUI
    {
        private BadgeContentRepository _badgeRepo = new BadgeContentRepository();

        public void Run()
        {
            seedContentList();
            Badge();
        }

        private void Badge()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                   "1. Create New Badge\n" +
                   "2. View All Badges\n" +
                   "3. Update/Remove Badge\n" +
                   "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //view all content
                        DisplayAllContent();
                        break;
                    case "3":
                        //view content by title
                        UpdateAllContent();
                        break;
                    case "4":
                        //update existing content
                        Console.WriteLine("goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
                




            }
        }

        private void CreateNewContent()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            Console.WriteLine("Enter badge id number");
            string idNumberAsString = Console.ReadLine();
            newBadge.BadgeId = int.Parse(idNumberAsString);

            Console.WriteLine("what doors can this badge access?");
            bool addDoors = true;
            Console.WriteLine("enter doors one at a time");
            List<string> _doors = new List<string> { Console.ReadLine() };

            while (addDoors)
            {
                Console.WriteLine("type 1 to add door, press 2 when finished.");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter door number");
                        _doors.Add(Console.ReadLine());
                        break;

                    case "2":
                        newBadge.ListOfDoors = _doors;
                        _badgeRepo.AddBadgeToDictionary(newBadge);
                        addDoors = false;
                        break;

                    default:
                        Console.WriteLine("press 1 or press 2");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayAllContent()
        {
            Console.Clear();
            Dictionary<int, Badges> BadgeDictionary = _badgeRepo.GetBadgesDictionary();

            foreach (KeyValuePair<int, Badges> badge in BadgeDictionary)
            {
                Console.WriteLine($"Badge ID\t" + $"Access door\t");
                Console.WriteLine($"{badge.Key}\t\t"+$"{_badgeRepo}\t\t");

                
            }
        }

        //private void DisplayAllContent()
        //{
        //    Console.Clear();
        //    Dictionary<int, Badges> BadgeDictionary = _badgeRepo.GetBadgesDictionary();

        //    foreach (KeyValuePair<int, Badges>badge in BadgeDictionary)
        //    {
        //        Console.WriteLine($"Badge ID\t" + $"Door access\t");

        //        foreach (string door in badge.Value)
        //        {
        //            Console.WriteLine($"{badge.Key}\t\t" + $"{door}\t\t");
        //        }
        //    }



        //}

        private void UpdateAllContent()
        {
            DisplayAllContent();

            Console.WriteLine("enter badge id you would like to update");
            int oldContent = int.Parse(Console.ReadLine());

            Badges newContent = new Badges();

            bool addDoors = true;
            List<string> _doors = new List<string> { Console.ReadLine() };

            while (addDoors)
            {
                Console.WriteLine("type 1 to add door, type 2 to remove door, type 3 when finished");

                var usesInput = Console.ReadLine();
                switch (usesInput)
                {
                    case "1":
                        Console.WriteLine("Type door number");
                        _doors.Add(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("type door you would like to remove");
                        _doors.Remove(Console.ReadLine());
                        break;

                    case "3":
                        
                        addDoors = false;
                        break;

                    default:
                        Console.WriteLine("Type 1 or 2");
                        Console.ReadKey();
                        break;
                }

                bool wasUpdated = _badgeRepo.UpdateExistingBadges(oldContent, newContent);

                if (wasUpdated)
                {
                    Console.WriteLine("content updated");
                }
                else
                {
                    Console.WriteLine("Did not update");
                }
            
            
            
            
            }
                

        }

        private void seedContentList()
        {

            Badges numberOne = new Badges(1, new List<string> { "1" });

            _badgeRepo.AddBadgeToDictionary(numberOne);
            
        
        
        }




    }
}
