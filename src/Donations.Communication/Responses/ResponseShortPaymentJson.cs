using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses
{
    public class ResponseShortPaymentJson
    {
        public Guid Id { get; set; }
        public Guid DonorId { get; set; } 
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}