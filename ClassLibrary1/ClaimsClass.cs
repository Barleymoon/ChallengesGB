using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
     public enum ClaimType { Car, Home, Theft }
    public class ClaimsClass
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public List<ClaimsClass> ClaimsList { get; set; }
        public DateTimeOffset DateOfClaim { get; set; }
        // public bool IsValid { get; }
        public ClaimsClass(ClaimType claimType, string description, decimal claimAmount, DateTime dateOfClaim, DateTime dateOfIncident)
        {
           // Random random = new Random();
           // ClaimId = random.Next(0,999999);
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            //IsValid = isValid;
            // DateOfIncident = dateOfIncident;
        }

        public ClaimsClass()
        {
        }

        public bool IsValid()
        {
            if (DateOfClaim >= DateOfIncident)
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
