using Donations.Communication.Requests;
using Donations.Exception.Resources;
using FluentValidation;

namespace Donations.Application.UseCases.Pledges.Register
{
    public class RegisterPledgeValidator : AbstractValidator<RequestRegisterPledgeJson>
    {
        public RegisterPledgeValidator()
        {
            RuleFor(request => request.PledgeDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(ExceptionMessages.PLEDGE_DATE_MUST_BE_AT_LEAST_TODAY_MESSAGE); //ResourceManagement.SpitResource("NAME_EMPTY")
            RuleFor(request => request.Amount)
                .NotEmpty()
                .WithMessage(ExceptionMessages.PAYMENT_NOT_FOUND_MESSAGE); //ResourceManagement.SpitResource("DATE_TRIP_MUST_BE_LATER_THAN_TODAY")
        }     
    }
}