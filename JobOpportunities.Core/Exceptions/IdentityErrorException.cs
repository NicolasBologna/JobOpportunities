using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Exceptions
{
    public class IdentityErrorException : Exception
    {
        public IdentityErrorException(IEnumerable<IdentityError> errors) : base("One or more validation failures have occurred.")
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
