using Donations.Communication.Responses;
using Donations.Infrastructure;

namespace Donations.Application.UseCases.Donors.GetAll
{
    public class GetAllDonorsUseCase
    {
        public ResponseDonorsJson Execute()
        {
            var dbContext = new DonationsDbContext();

            var donors = dbContext.Donors.ToList();

            return new ResponseDonorsJson
            {
                Donors = donors.Select(donor => new ResponseShortDonorJson 
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    ActiveStatus = donor.ActiveStatus,
                    Address = donor.Address,
                }).ToList()
            };
        }
    }
}