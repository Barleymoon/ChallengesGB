using Challenge1_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1_Tests
{
    [TestClass]
    public class MenuItemsTests
    {
        private Challenge1_Repo.MenuItems_Repo _repo;
        private MenuItems _inventory;
        private MenuItems thePorkChop;
       

        [TestInitialize]
        public void Seed()
        {
            _repo = new MenuItems_Repo();
            thePorkChop = new MenuItems(
                 1,
                "The ProkChop",
                "Amazingly prepaired Porkchop.",
                15,
                new List<string> { "", "", }
                );
            MenuItems theSalad = new MenuItems(
                2,
                "Salad",
                "Amazing Salad with fresh greens and lots of variety.",
                16,
                new List<string> {  "", "", }
                );
            _repo.AddItemsToInventory(thePorkChop);
            _repo.AddItemsToInventory(theSalad);
        }

        [TestMethod]
        public void AddToInventoryTest()
        {
            MenuItems theHouseBurger = new MenuItems(
                3,
                "The House Burger",
                "Great 8 ounce patty topped with Pepperjack cheese and veggies.",
                15,
                new List<string> { "", "", }
                );
            bool wasAdded = _repo.AddItemsToInventory(theHouseBurger);

            Console.WriteLine(_repo.Count);

            Console.WriteLine(wasAdded);
            Console.WriteLine(_inventory.Name.ToLower());


            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void FindItemByName()
        {
            MenuItems searchResult = _repo.GetItemsByName("the Pork Chop");

            Assert.AreEqual(searchResult, thePorkChop);
        }

        [TestMethod]
        public void DeleteMenuItems_Deleted()
        {
            bool wasRemoved = _repo.DeleteItems("the pork chop");
            Assert.IsTrue(wasRemoved);
        }
    }
}
