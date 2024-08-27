using Donations.Application.UseCases.Pledges.Delete;
using Donations.Application.UseCases.Pledges.Register;
using Donations.Communication.Requests;
using Donations.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Donations.API.Controllers
{
    public class PledgesController : ControllerBase
    {
        [HttpPost]
        [Route("{donorId}/pledge")]
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

        [HttpDelete]
        [Route("{donorId}/pledge/{pledgeId}")]
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
}