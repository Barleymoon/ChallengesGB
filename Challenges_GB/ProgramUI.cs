﻿using Challenge1_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_GB
{
    public class ProgramUI
    {
        private readonly MenuItems_Repo _repo = new MenuItems_Repo();
        public void Run()
        {
            Console.WriteLine("Welcome to Komodo Cafe");
            Console.ReadKey();
        }
        private void RunMenu()
        {
            bool continueToDisplay = true;
            while (continueToDisplay)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you wish to choose." +
                    "1. Show All Menu Items." +
                    "2. Create a New Menu Item" +
                    "3. Delete a Menu Item from Inventory." +
                    "4. Exit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        // CreateNewItem();
                        break;
                    case "3":
                        DeleteExistingItemFromList();
                        break;
                    case "4":
                        // ExitProgram
                        continueToDisplay = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            List<MenuItems> ListOfMenuItems = _repo.ShowItems();

            foreach (MenuItems items in ListOfMenuItems)
            {
                DisplayItems(items);
            }
            Console.ReadKey();
        }

        private void DisplayItems(MenuItems items)
        {
            Console.WriteLine($"Name: {items.Name}" +
                // $"ID: {items.ID}" +
                $"Description: {items.Description}" +
                $"Price: {items.Price}" +
                $"Ingredients: {items.Ingredients}");
        }

        private void DeleteExistingItemFromList()
        {
            Console.Clear();

            Console.WriteLine("Which item would you like to delete from the list?");

            List<MenuItems> MenuList = _repo.ShowItems();

            int count = 0;

            foreach (MenuItems items in MenuList)
            {
                count++;
                Console.WriteLine($"{count}. {items.Name}");
            }

            int targetItemsId = int.Parse(Console.ReadLine());

            int targetIndex = targetItemsId - 1;

            if (targetIndex >= 0 && targetIndex < MenuList.Count)
            {
                MenuItems desiredItems = MenuList[targetIndex];

                if (_repo.DeleteItems(desiredItems.Name))
                {
                    Console.WriteLine($"{desiredItems.Name} successfully deleted from the Menu List.");
                }
                else
                {
                    Console.WriteLine("I am sorry I can not preform that.");
                }
            }
            else
            {
                Console.WriteLine("I'm sorry, there is no Menu Item with that Name.");
            }
            Console.ReadKey();
        }
    }
}
