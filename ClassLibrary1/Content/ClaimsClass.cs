using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class ClaimsClass
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTimeOffset DateOfClaim { get; set; }
        // public bool IsValid { get; }
        public ClaimsClass(int claimId, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfClaim, DateTime dateOfIncident)
        {
            Random random = new Random();
            ClaimId = random.Next(0,999999);
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            //IsValid = isValid;
            // DateOfIncident = dateOfIncident;
        }
        public bool IsValid()
        {
            if (DateOfIncident <= DateOfClaim)
            {
                return true;
            }
            else if (DateOfIncident <= DateOfClaim)
            {
                return false;
            }
            return true;
        }
    }
}
