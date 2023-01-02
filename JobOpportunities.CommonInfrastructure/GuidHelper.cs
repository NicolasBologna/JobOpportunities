using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.CommonInfrastructure
{
    public static class GuidHelper
    {
        public static bool IsValidGuid(Guid? guid)
        {
            return guid != Guid.Empty && guid is not null;
        }
    }
}
