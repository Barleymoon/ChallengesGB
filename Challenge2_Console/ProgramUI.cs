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
        private readonly ClaimsClass_Repo _repo = new ClaimsClass_Repo();

        public void Run()
        {
            Console.ReadKey();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like to do today." +
                    "1. Show the Queue." +
                    "2. Take care of the next claim." +
                    "3. Add a new Claim to the queue." +
                    "4. Exit the program.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowTheQueue();
                        break;
                    case "2":
                        //MoveToNextClaim();
                        break;
                    case "3":
                        //AddNewClaim
                        break;
                    case "4":
                        //Exit
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

        private void MoveToNextClaim(ClaimsClass claims)
        {
            Console.Clear();

        }

        private void AddNewClaim(ClaimsClass claims)
        {
            Console.Clear();

            ClaimsClass newClaims = new ClaimsClass();

            
            // string claimIdString = Console.ReadLine();


            Console.WriteLine("Please enter the ClaimType: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string ClaimTypeString = Console.ReadLine();

            Console.WriteLine("Please enter a description of the claim: ");
            claims.Description = Console.ReadLine();

            Console.WriteLine("Amount for damage: ");
            claims.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Date Of Accident: ");
            claims.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Date of Claim: ");
            claims.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

        }
    }
}
