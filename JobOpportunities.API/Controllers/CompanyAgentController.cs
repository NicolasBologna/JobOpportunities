using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    public class CompanyAgentController : ApiControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<List<CompanyAgent>>> Get()
        //{
        //    return await Mediator.Send(new GetCompanyAgentsQuery() { })
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove(Guid id)
        {
            await Mediator.Send(new RemoveCompanyAgentCommand() { Id = id });
            return NoContent();
        }
    }
}
