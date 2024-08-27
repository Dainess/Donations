using Donations.Communication.Responses;
using Donations.Exception.ExceptionBase;
using Donations.Exception.Resources;
using Donations.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Donations.Application.UseCases.Donors.GetById
{
    public class GetDonorByIdUseCase
    {
        private readonly DonationsDbContext _dbContext;
        public GetDonorByIdUseCase() 
        {
            _dbContext = new DonationsDbContext();
        }

        public ResponseFullDonorJson Execute(int id) 
        {
            // var donor = _dbContext.Donors
            //     .Where(donor => donor.Id == id)
            //     .Include(donor => donor.Pledges)
            //     .FirstOrDefault(donor => donor.Id == id);

            var donor = _dbContext.Donors
                .Include(donor => donor.Pledges)
                .FirstOrDefault(donor => donor.Id == id);

            if (donor is null)
                throw new NotFoundException(ExceptionMessages.DONOR_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("TRIP_NOT_FOUND")

            return new ResponseFullDonorJson
            {
                Id = donor.Id,
                Name = donor.Name,
                ActiveStatus = donor.ActiveStatus,
                Address = donor.Address,
                RegisteredSince = donor.RegisteredSince,
                Pledges = donor.Pledges.Select(pledge => new ResponseShortPledgeJson{
                    Id = pledge.Id,
                    DonorId = pledge.DonorId,
                    PledgeDate = pledge.PledgeDate,
                    Amount = pledge.Amount
                }).ToList(),
                Payments = donor.Payments.Select(payment => new ResponseShortPaymentJson{
                    Id = payment.Id,
                    DonorId = payment.DonorId,
                    PaymentDate = payment.PaymentDate,
                    Amount = payment.Amount
                }).ToList()
            };
        }
    }
}