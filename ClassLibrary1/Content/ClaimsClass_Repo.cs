using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ClaimsClass_Repo
    {
        private readonly List<ClaimsClass> _reports = new List<ClaimsClass>();

        public int Count
        {
            get
            {
                return _reports.Count;
            }
        }

        public bool AddContentToClaims(ClaimsClass claims)
        {
            int startingCount = _reports.Count;

            _reports.Add(claims);

            bool wasAdded = _reports.Count > startingCount;
            return wasAdded;
        }
        public List<ClaimsClass> GetClaims()
        {
            return _reports;
        }

        public ClaimsClass GetClaimById(int claimId)
        {
            foreach (ClaimsClass claims in _reports)
            {
                if (claimId == claims.ClaimId)
                {
                    return claims;
                }
            }
            return null;
        }

        public bool ClaimsToDelete(int claimId)
        {
            ClaimsClass claimToDelete = GetClaimById(claimId);
            return _reports.Remove(claimToDelete);
        }
    }
}
