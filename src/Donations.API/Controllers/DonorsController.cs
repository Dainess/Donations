using Microsoft.AspNetCore.Mvc;
using Donations.Application.UseCases.Donors.Register;
using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Donations.Application.UseCases.Donors.GetAll;
using Donations.Application.UseCases.Donors.GetById;
using Donations.Application.UseCases.Donors.Delete;
using Donations.Application.UseCases.Donors.ActiveStatus;

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

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDonorsJson),StatusCodes.Status200OK)]
    public IActionResult GetAll() 
    {
        var useCase = new GetAllDonorsUseCase();
        var result = useCase.Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseFullDonorJson),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id) 
    {
        var useCase = new GetDonorByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{donorId}/activitystatus/{status}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult ChangeActivityStatus(
        [FromRoute] int donorId,
        [FromRoute] bool status)
    {
        var useCase = new ChangeActiveStatusOfDonorUseCase();
        useCase.Execute(donorId, status);
        return NoContent();
    }

    // [HttpPut]
    // [Route("{donorId}/address/{address}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    // public IActionResult ChangeAddress(
    //     [FromRoute] Guid donorId,
    //     [FromRoute] bool address)
    // {
    //     var useCase = new ChangeAddressOfDonorUseCase();
    //     useCase.Execute(donorId, address);
    //     return NoContent();
    // }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status404NotFound)]
    public IActionResult DeleteById([FromRoute] int id) 
    {
        var useCase = new DeleteDonorByIdUseCase();
        useCase.Execute(id);
        return NoContent();
    }
}