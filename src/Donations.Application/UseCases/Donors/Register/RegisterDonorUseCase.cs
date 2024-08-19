using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Donations.Infrastructure;
using Donations.Infrastructure.Entities;

namespace Donations.Application.UseCases.Donors.Register;
public class RegisterDonorUseCase
{
    public ResponseShortDonorJson Execute(RequestRegisterDonorJson request)
    {
        //Validate(request);

        var dbContext = new DonationsDbContext();

        var entity = new Donor
        {
            Name = request.Name,
            Address = request.Address,
            ActiveStatus = request.ActiveStatus,
        };

        dbContext.Donors.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortDonorJson 
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            ActiveStatus = entity.ActiveStatus
        };
    }

    // private void Validate(RequestRegisterTripJson request)
    // {
    //     var validator = new RegisterTripValidator();
    //     var result = validator.Validate(request);

    //     if (result.IsValid == false)
    //     {
    //         var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

    //         throw new ErrorOnValidationException(errorMessages);
    //     }
    // }

}