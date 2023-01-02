using JobOpportunities.Data.Identity;
using JobOpportunities.Data.UnitTest.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobOpportunities.Data.UnitTest.Stubs
{
    public class JobOpportunitiesContext_Stub : JobOpportunitiesContext
    {
        public JobOpportunitiesContext_Stub(DbContextOptions<JobOpportunitiesContext> options, ICurrentUserService currentUserService) : base(options, currentUserService)
        {
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Func<Task<int>>[] functions = {
            //    () => throw new Exception("Database Error!"),
            //    async () => await base.SaveChangesAsync(cancellationToken)
            //};
            if (base.Skills.First().SeniorityId != DefaultGUIDS.DefaultCreationForFailureGUID)
            {
                throw new Exception("Database Error!");
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
