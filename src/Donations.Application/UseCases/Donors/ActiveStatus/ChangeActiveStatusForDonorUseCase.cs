using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;

namespace Donations.Application.UseCases.Donors.ActiveStatus
{
    public class ChangeActiveStatusForDonorUseCase
    {
        private readonly DonationsDbContext _dbContext;

        public ChangeActiveStatusForDonorUseCase()
        {
            _dbContext = new DonationsDbContext();
        }

        public void Execute(Guid donorId, bool complete)
        {
            var donor = _dbContext
                .Donors
                .FirstOrDefault(donor => donor.Id == donorId);

            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("ACTIVITY_NOT_FOUND")
            
            donor.ActiveStatus = false;

            _dbContext.Donors.Update(donor);
            _dbContext.SaveChanges();
        }
    }
}