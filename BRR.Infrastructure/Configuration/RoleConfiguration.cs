using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("nombre")
            .HasMaxLength(128)
            .IsUnicode(false)
            .IsRequired();

    }
}
