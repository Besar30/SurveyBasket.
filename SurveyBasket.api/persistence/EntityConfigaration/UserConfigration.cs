﻿
namespace SurveyBasket.api.persistence.EntityConfigaration
{
    public class UserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.OwnsMany(x => x.RefreshTokens)
                .ToTable("RefreshTokens")
                .WithOwner()
                .HasForeignKey("UserId");
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x=>x.LastName).HasMaxLength(100);
        }
    }
}
