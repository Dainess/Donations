using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;

namespace Donations.Application.UseCases.Donors.Address;

public class ChangeAddressOfDonorUseCase
{
    private readonly DonationsDbContext _dbContext;

    public ChangeAddressOfDonorUseCase() 
    {
        _dbContext = new DonationsDbContext();
    }

    public void Execute(int donorId, string address)
    {
        var donor = _dbContext
            .Donors
            .FirstOrDefault(donor => donor.Id == donorId);
        
        if (donor is null)
            throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE);
        
        donor.Address = address;

        _dbContext.Donors.Update(donor);
        _dbContext.SaveChanges();
    }
}
