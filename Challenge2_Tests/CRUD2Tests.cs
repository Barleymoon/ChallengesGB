using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2_Tests
{
    [TestClass]
    public class CRUD2Tests
    {
        private ClassLibrary1.ClaimsClass_Repo _repo;
        private ClassLibrary1.ClaimsClass _reports;
        [TestInitialize]
        public void Seed()
        {
            _repo = new ClaimsClass_Repo();

            ClaimsClass One = new ClaimsClass(
                ClaimType.Car,
                "Accident on 465.",
                400,
                new DateTime(10 / 25 / 18),
                new DateTime(10 / 27 / 18)
                );
            ClaimsClass Two = new ClaimsClass(
                ClaimType.Home,
                "Tree fell through garage.",
                4000,
                new DateTime(04 / 11 / 18),
                new DateTime(04 / 12 / 18)
                );
            ClaimsClass Three = new ClaimsClass(
                ClaimType.Theft,
                "Stolen hair dryer.",
                25,
                new DateTime(04 / 27 / 18),
                new DateTime(06 / 01 / 18)
                );
            _repo.AddNewContentToClaims(One);
            _repo.AddNewContentToClaims(Two);
            _repo.AddNewContentToClaims(Three);

            _reports = new ClaimsClass(
                ClaimType.Home,
                "House caught on fire during Summer.",
                25000,
                new DateTime(05 / 21 / 18),
                new DateTime(06 / 12 / 18)
                );
            _repo.AddNewContentToClaims(_reports);
        }

        [TestMethod]
        public void AddClaimsTest()
        {
            ClaimsClass _reports = new ClaimsClass(
                ClaimType.Car,
                "Car accident on 464.",
                400,
                new DateTime(04 / 25 / 18),
                new DateTime(04 / 27 / 18)
                );

            bool wasAdded = _repo.AddNewContentToClaims(_reports);

            Console.WriteLine(_repo.Count);

            Console.WriteLine(wasAdded);
            Console.WriteLine(_reports.ClaimId);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DeleteClaims_ShouldDelete()
        {
            bool wasRemoved = _repo.ClaimsToDelete(2);
            Assert.IsTrue(wasRemoved);
        }
    }
}
