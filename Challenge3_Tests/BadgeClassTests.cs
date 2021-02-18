using Challenge3_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3_Tests
{
       // private Dictionary<int, string> Doors = new Dictionary<int, string>();
    [TestClass]
    public class BadgeClassTests
    {
        private Challenge3_Repo.BadgesClass_Repo _repo;
        private Challenge3_Repo.BadgesClass _badgeClass;
        private BadgesClass badgeOne;

        [TestInitialize]
        public void Seed()
        {
            _repo = new BadgesClass_Repo();
            badgeOne = new BadgesClass(
                12345,
                new List<string> {}
                );
            BadgesClass badgeTwo = new BadgesClass(
                14345,
                new List<string> { }
                );
            _repo.AddToNewBadges(badgeOne);
            _repo.AddToNewBadges(badgeTwo);
        }
        [TestMethod]
        public void FindDoorAccessByID()
        {
            BadgesClass searchResult = _repo.GetDoorAccessThroughID(16345);

            Assert.AreEqual(searchResult, 16345);
        }
        [TestMethod]
        public void UpdateDoorAccessByID()
        {
            BadgesClass newDoorAcess = new BadgesClass(
                12345,
                new List<string> { }
                );
            bool wasUpdated = _repo.UpdateAccessToDoorsFromBadgeID(12345, newDoorAcess);

            Assert.IsTrue(wasUpdated);

            BadgesClass updatedDoorAccess = _repo.GetDoorAccessThroughID(12345);
            Console.WriteLine(updatedDoorAccess.BadgeID);
        }
        [TestMethod]
        public void RemoveDoorAccessByID()
        {
            bool wasRemoved = _repo.RemoveDoorFromBadgeID(14456);
            Assert.IsTrue(wasRemoved);
        }
        public void CreateNewBadgeTests()
        {
            BadgesClass badges = new BadgesClass(
                16345,
                new List<string> { }
                );

             _repo.AddToNewBadges(badges);
        }
    }
}
