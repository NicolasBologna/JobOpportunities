using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Data.Configurations
{
    internal class JobOffersConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            //  builder.HasMany(x => x.Candidates).WithMany(c => c.OffersApplied).DeleteBehavior;
        }
    }
}
