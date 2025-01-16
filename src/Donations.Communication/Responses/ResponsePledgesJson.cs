using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donations.Communication.Responses;

public class ResponsePledgesJson
{
    public IList<ResponseShortPledgeJson> Pledges { get; set; } = [];
}
