using Microsoft.AspNetCore.Mvc;
using Donations.Application.UseCases.Donors.Register;
using Donations.Communication.Requests;

namespace Donations.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class DonorsController : ControllerBase
{
    [HttpPost]
    // [ProducesResponseType(typeof(ResponseShortTripJson),StatusCodes.Status201Created)]
    // [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterDonorJson request)
    {
        var useCase = new RegisterDonorUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response); 
           
        // try
        // {
                    
        // }
        // catch (JourneyException ex)
        // {
        //     string coco = " | ";
        //     foreach (var item in ex.GetErrorMessages())
        //     {
        //         coco += item + " | ";
        //     }
        //     return BadRequest(coco);
        // }
        // catch
        // {
        //     return StatusCode(StatusCodes.Status500InternalServerError, ResourceManagement.SpitResource("UNKNOWN_ERROR"));
        // }
    }
}