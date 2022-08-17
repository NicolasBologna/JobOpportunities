using JobOpportunities.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobOpportunities.Data.Configurations
{
    public class AccessTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(q => q.RefreshTokenId);

            builder.Property(q => q.RefreshTokenValue)
                .IsRequired();

            builder.Property(q => q.UserId)
                .IsRequired();

            builder.HasOne(q => q.User)
                .WithMany(q => q.AccessTokens)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
