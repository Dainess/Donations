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
        public ResponseShortPledgeJson Execute(Guid donorId, RequestRegisterPledgeJson request)
        {
            var dbContext = new DonationsDbContext();

            var donor = dbContext
                .Donors
                .Where(donor => donor.Id == donorId)
                .Include(donor => donor.Pledges)
                .First();
                // .Include(donor => donor.Pledges)
                // .FirstOrDefault(donor => donor.Id == donorId);

            Validate(donor, request);

            var entity = new Pledge
            {
                PledgeDate = request.PledgeDate,
                Amount = request.Amount,
                DonorId = donorId,
                Donor = donor
            };

            dbContext.Pledges.Add(entity);
            //donor!.Pledges.Add(entity);
            //var newDonor = dbContext.Donors.Include(donor => donor.Pledges).SingleOrDefault(donor => donor.Pledges.FirstOrDefault(pledge => pledge.Id == entity.Id) != null);
            dbContext.Donors.Update(donor);

            dbContext.SaveChanges();

            return new ResponseShortPledgeJson
            {
                Id = entity.Id,
                DonorId = entity.DonorId,
                PledgeDate = entity.PledgeDate,
                Amount = entity.Amount,
            };
        }

        private void Validate(Donor? donor, RequestRegisterPledgeJson request)
        {
            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")

            var validator = new RegisterPledgeValidator();
            var result = validator.Validate(request);

            // if (donor.StartDate.Date > request.Date || donor.EndDate.Date < request.Date)
            // {
            //     result.Errors.Add(new ValidationFailure("Date", ResourceManagement.SpitResource("DATE_NOT_WITHIN_TRAVEL_PERIOD")));
            // }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}