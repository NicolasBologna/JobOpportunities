using JobOpportunities.Core.Features.Auth.Commands;
using JobOpportunities.Core.Features.Auth.Models;
using JobOpportunities.Core.Features.Candidates.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    public class CandidateController : ApiControllerBase
    {
        [HttpPost("UploadCV")]
        public async Task<IActionResult> UploadCV([FromForm] UploadCVCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
