using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses
{
    public class ResponseShortPaymentJson
    {
        public int Id { get; set; }
        public int DonorId { get; set; } 
        public string DonorName { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}