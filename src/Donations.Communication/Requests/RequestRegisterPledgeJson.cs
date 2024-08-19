using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Requests
{
    public class RequestRegisterPledgeJson
    {
        public DateTime PledgeDate { get; set; }
        public decimal Amount { get; set; }
    }
}