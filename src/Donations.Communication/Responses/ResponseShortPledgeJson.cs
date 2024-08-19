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
    }
}