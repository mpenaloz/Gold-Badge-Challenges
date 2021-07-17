using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class ClaimRepo
    {
        private Queue<Claims> _listOfClaims = new Queue<Claims>();
        private int _count;
        public bool AddClaimToList(Claims claim)
        {
            if (claim is null)
            {
                return false;
            }
            else
            {
                _count++;
                claim.ClaimID = _count;
                _listOfClaims.Enqueue(claim);
                return true;
            }
        }
        public Queue<Claims> GetClaimList()
        {
            return _listOfClaims;
        }
        public bool RemoveClaimFromList()
        {
            if (_listOfClaims.Count > 0)
            {
                _listOfClaims.Dequeue();
                return true;
            }
            return false;
        }
        public Claims GetNextClaim()
        {
            var claim = _listOfClaims.Peek();
            if (claim != null)
            {
                return claim;
            }
            return null;

        }
    }
}
