using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations.Communication.Responses;
using Donations.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Donations.Application.UseCases.Pledges.GetAll;

public class GetAllPledgesUseCase
{
    public ResponsePledgesJson Execute()
    {
        var dbContext = new DonationsDbContext();

        var donors = dbContext
            .Donors
            .Include(donor => donor.Pledges)
            .ToList();

        return new ResponsePledgesJson
        {
            Pledges = donors.Select(donor => donor.Pledges.Select(pledge => new ResponseShortPledgeJson {
                    Id = pledge.Id,
                    DonorId = donor.Id,
                    DonorName = donor.Name,
                    PledgeDate = pledge.PledgeDate,
                    Amount = pledge.Amount,
                })).SelectMany(pledge => pledge).ToList()
            
        };
    }
}
