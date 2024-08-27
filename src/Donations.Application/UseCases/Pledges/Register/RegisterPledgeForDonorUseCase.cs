using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;
using Donations.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Donations.Application.UseCases.Pledges.Register
{
    public class RegisterPledgeForDonorUseCase
    {
        public ResponseShortPledgeJson Execute(int donorId, RequestRegisterPledgeJson request)
        {
            var dbContext = new DonationsDbContext();

            var donor = dbContext
                .Donors
                .Where(donor => donor.Id == donorId)
                .Include(donor => donor.Pledges)
                .First();

            Validate(donor, request);

            var entity = new Pledge
            {
                PledgeDate = request.PledgeDate,
                Amount = request.Amount,
                DonorId = donorId,
                Donor = donor
            };

            donor!.Pledges.Add(entity);
            dbContext.Donors.Update(donor);

            dbContext.SaveChanges();

            return new ResponseShortPledgeJson
            {
                Id = entity.Id,
                DonorId = entity.DonorId,
                DonorName = entity.Donor.Name,
                PledgeDate = entity.PledgeDate,
                Amount = entity.Amount
            };
        }

        private void Validate(Donor? donor, RequestRegisterPledgeJson request)
        {
            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")

            var validator = new RegisterPledgeValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}