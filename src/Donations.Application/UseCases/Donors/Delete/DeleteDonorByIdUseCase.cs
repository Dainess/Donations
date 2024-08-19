using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;

namespace Donations.Application.UseCases.Donors.Delete
{
    public class DeleteDonorByIdUseCase
    {
        private readonly DonationsDbContext _dbContext;
        public DeleteDonorByIdUseCase() 
        {
            _dbContext = new DonationsDbContext();
        }

        public void Execute(Guid id) 
        {
            var donor = _dbContext
                .Donors
                //.Include(trip => trip.Activities)
                .FirstOrDefault(donor => donor.Id == id);

            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")

            _dbContext.Donors.Remove(donor);
            _dbContext.SaveChanges();
        }
    }
}