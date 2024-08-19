using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses
{
    public class ResponseDonorsJson
    {
        public IList<ResponseShortDonorJson> Donors { get; set; } = [];
    }
}