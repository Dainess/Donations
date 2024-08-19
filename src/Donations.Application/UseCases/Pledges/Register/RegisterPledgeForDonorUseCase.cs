using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;
using Donations.Infrastructure.Entities;

namespace Donations.Application.UseCases.Pledges.Register
{
    public class RegisterPledgeForDonorUseCase
    {
        public ResponseShortPledgeJson Execute(Guid donorId, RequestRegisterPledgeJson request)
        {
            var dbContext = new DonationsDbContext();

            var donor = dbContext
            .Donors
            //.Include(trip => trip.Activities)
            //morre por causa do bug do SQLite
            .FirstOrDefault(donor => donor.Id == donorId);
        
            Validate(donor, request);

            var entity = new Pledge
            {
                PledgeDate = request.PledgeDate,
                Amount = request.Amount,
                DonorId = donorId
            };

            donor!.Pledges.Add(entity);
            dbContext.Donors.Update(donor);

            //trip!.Activities.Add(entity);
            //06 meteu que só de fazer esse Add dentro dessa IList o EntityFramework vai entender que é pra adicionar essa parada dentro da tabela activities 
            //e meter a private key tripId 
            //dbContext.Trips.Update(trip);
            //essas aqui morrem por causa do bug do SQLite
            
            //dbContext.Activities.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortPledgeJson
            {
                Id = entity.Id,
                DonorId = entity.DonorId,
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