using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.Users.Models
{
    public class GetUserQueryResponse
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Id { get; set; } = null!;
    }
}
