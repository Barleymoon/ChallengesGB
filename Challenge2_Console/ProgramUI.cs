using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Console
{
    public class ProgramUI
    {
        // private readonly List<ClaimsClass> _reports = new List<ClaimsClass>();

        private readonly ClaimsClass_Repo _repo = new ClaimsClass_Repo();

        public void Run()
        {
            Console.ReadKey();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like to do today.\n" +
                    "1. Show the Queue.\n" +
                    "2. Take care of the next claim.\n" +
                    "3. Add a new Claim to the queue.\n" +
                    "4. Exit the program.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowTheQueue();
                        break;
                    case "2":
                        MoveToNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowTheQueue()
        {
            Console.Clear();

            List<ClaimsClass> listOfClaims = _repo.GetClaims();

            foreach (ClaimsClass claims in listOfClaims)
            {
                DisplayClaims(claims);
            }
            Console.ReadKey();
        }
        private void DisplayClaims(ClaimsClass claims)
        {
            Console.WriteLine($"ClaimId: {claims.ClaimId}\n" +
                $"ClaimType: {claims.ClaimType}\n" +
                $"Description: {claims.Description}\n" +
                $"ClaimAmount: {claims.ClaimAmount}\n" +
                $"DateOfIncident: {claims.DateOfIncident}\n" +
                $"DateOfClaim: {claims.DateOfClaim}\n");
        }
        
        private void MoveToNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Would you like to deal with this claim now?\n " +
                "1. Yes\n" +
                "2. No\n");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    //SelectThisClaim
                    ClaimToDelete();
                    break;
                case "2":
                    //MoveDownTheQueue
                    ShowTheQueue();
                    break;
                default:
                    Console.WriteLine("Please select a valid number between 1-3.");
                    break;
            }
        }
        private void ClaimToDelete()
        {
            Console.Clear();

            Console.WriteLine("Comfirm Which Claim to Remove.");

            List<ClaimsClass> claimsList = _repo.GetClaims();

            foreach (ClaimsClass claims in claimsList)
            {
                DisplayClaims(claims);
            }
            Console.ReadKey();
        }


        private void AddNewClaim()
        {
            Console.Clear();

            ClaimsClass newClaims = new ClaimsClass();

            Console.WriteLine("Please enter the ClaimType: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            // string newClaimTypeString = Console.ReadLine();
            // int newClaimType = int.Parse(newClaimTypeString); 
            // newClaims.ClaimType claimType = Console.ReadLine();

            Console.WriteLine("Please enter a description of the claim: ");
            newClaims.Description = Console.ReadLine();

            Console.WriteLine("Amount for damage: ");
            newClaims.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Date Of Accident: ");
            newClaims.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Date of Claim: ");
            newClaims.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            _repo.AddNewContentToClaims(newClaims);

        }
        public static ClaimsClass ClaimOne = new ClaimsClass(
            ClaimType.Car,
            "Car struck by hail",
            4000,
            new DateTime(04 / 01 / 19),
            new DateTime(04 / 02 / 19)
            );
    }
}
