using Donations.Communication.Requests;
using Donations.Communication.Responses;

namespace Donations.Application.UseCases.Donors.Register;
public class RegisterDonorUseCase
{
    public ResponseShortDonorJson Execute(RequestRegisterDonorJson request)
    {
        //Validate(request);

        //var dbContext = new JourneyDbContext();

        // var entity = new Trip 
        // {
        //     Name = request.Name,
        //     StartDate = request.StartDate,
        //     EndDate = request.EndDate,
        // };

        // dbContext.Trips.Add(entity);

        // dbContext.SaveChanges();

        return new ResponseShortDonorJson 
        {
            Name = "Jão",
            Address = "Rua Bueno de Paiva, 200, 204",
            ActiveStatus = true
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