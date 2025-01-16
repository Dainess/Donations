using Donations.Application.UseCases.Pledges.Delete;
using Donations.Application.UseCases.Pledges.GetAll;
using Donations.Application.UseCases.Pledges.GetByDonor;
using Donations.Application.UseCases.Pledges.Register;
using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers;

[Route("api/[controller]")]
public class PledgesController : ControllerBase
{
    [HttpPost]
    [Route("{donorId}")]
    [ProducesResponseType(typeof(ResponseShortPledgeJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Register(
        [FromRoute] int donorId,
        [FromBody] RequestRegisterPledgeJson request)
    {
        var useCase = new RegisterPledgeForDonorUseCase();
        var response = useCase.Execute(donorId, request);
        return Created(string.Empty, response); 
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponsePledgesJson),StatusCodes.Status200OK)]
    public IActionResult GetAll() 
    {
        var useCase = new GetAllPledgesUseCase();
        var result = useCase.Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{donorId}")]
    [ProducesResponseType(typeof(ResponsePledgesJson),StatusCodes.Status200OK)]
    public IActionResult GetByDonor([FromRoute] int donorId) 
    {
        var useCase = new GetByDonorUseCase();
        var result = useCase.Execute(donorId);
        return Ok(result);
    }

    

    [HttpDelete]
    [Route("{donorId}/{pledgeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status404NotFound)]
    public IActionResult DeleteActivityById(
        [FromRoute] int donorId, 
        [FromRoute] int pledgeId) 
    {
        var useCase = new DeletePledgeByIdUseCase();
        useCase.Execute(donorId, pledgeId);
        return NoContent();
    }
}
