using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses
{
    public class ResponseFullDonorJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; } 
        public DateTime RegisteredSince { get; set; }
        public IList<ResponseShortPledgeJson> Pledges { get; set; } = [];
        public IList<ResponseShortPaymentJson> Payments { get; set; } = [];
    }
}