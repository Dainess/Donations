using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;

namespace Donations.Application.UseCases.Pledges.Delete
{
    public class DeletePledgeByIdUseCase
    {
        private readonly DonationsDbContext _dbContext;
        public DeletePledgeByIdUseCase() 
        {
            _dbContext = new DonationsDbContext();
        }

        public void Execute(Guid donorId, Guid pledgeId) 
        {
            var donor = _dbContext
                .Donors
                //.Include(trip => trip.Activities)
                .FirstOrDefault(donor => donor.Id == donorId);

            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")
            
            var pledge = donor
                .Pledges
                .FirstOrDefault(pledge => pledge.Id == pledgeId);
            
            if (pledge is null)
                throw new NotFoundException(ExceptionMessages.PLEDGE_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")

            //donor.Pledges.Remove(pledge);
            _dbContext.Update(donor);
            _dbContext.SaveChanges();
        }
    }
}