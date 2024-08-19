using Donations.Communication.Requests;
using Donations.Exception.Resources;
using FluentValidation;

namespace Donations.Application.UseCases.Donors.Register
{
    public class RegisterDonorValidator : AbstractValidator<RequestRegisterDonorJson>
    {
        public RegisterDonorValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ExceptionMessages.NAME_EMPTY_MESSAGE); //ResourceManagement.SpitResource("NAME_EMPTY")
            RuleFor(request => request.Address)
                .NotEmpty()
                .WithMessage(ExceptionMessages.ADDRESS_EMPTY_MESSAGE); //ResourceManagement.SpitResource("DATE_TRIP_MUST_BE_LATER_THAN_TODAY")
        }
    }
}