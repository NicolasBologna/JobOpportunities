using System.Security.Claims;

namespace JobOpportunities.Core.Features.Auth.Models
{
    public class TokenInfoQueryResponse
    {
        public string Name { get; set; }
        public bool IsAuthenticated { get; set; }
        public string AuthenticationType { get; set; }
        public IEnumerable<object> Claims { get; set; }
    }
}
