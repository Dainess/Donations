using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses
{
    public class ResponseShortPledgeJson
    {
        public Guid Id { get; set; }
        public Guid DonorId { get; set; } 
        public DateTime PledgeDate { get; set; }
        public decimal Amount { get; set; }
        //public IList<ResponseShortPledgeJson> Pledges { get; set; } = [];
        //Isso foi feito só pra testar a exception de achar 0 rows no RegisterPledgeForDonor
    }
}