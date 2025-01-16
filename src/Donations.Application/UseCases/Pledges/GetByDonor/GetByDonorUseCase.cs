using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations.Communication.Responses;
using Donations.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Donations.Application.UseCases.Pledges.GetByDonor;

public class GetByDonorUseCase
{
    public ResponsePledgesJson Execute(int donorId)
    {
        var dbContext = new DonationsDbContext();

        var donor = dbContext
            .Donors
            .Include(donor => donor.Pledges)
            .First(donor => donor.Id == donorId);

        return new ResponsePledgesJson
        {
            Pledges = [.. donor.Pledges.Select(pledge => new ResponseShortPledgeJson {
                    Id = pledge.Id,
                    DonorId = donor.Id,
                    DonorName = donor.Name,
                    PledgeDate = pledge.PledgeDate,
                    Amount = pledge.Amount
                })]
        };
    }
}
