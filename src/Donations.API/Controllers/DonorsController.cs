using Microsoft.AspNetCore.Mvc;
using Donations.Application.UseCases.Donors.Register;
using Donations.Communication.Requests;
using Donations.Communication.Responses;

namespace Donations.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class DonorsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortDonorJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterDonorJson request)
    {
        var useCase = new RegisterDonorUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response); 
    }
}