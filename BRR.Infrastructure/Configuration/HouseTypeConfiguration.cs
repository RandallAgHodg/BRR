using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class HouseTypeConfiguration : IEntityTypeConfiguration<HouseType>
{
    public void Configure(EntityTypeBuilder<HouseType> builder)
    {
        builder.ToTable("TipoCasa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("nombre");

        builder.HasData(HouseType.PopulateDatabase());

        builder.HasMany(x => x.Houses)
            .WithOne(x => x.HouseType)
            .HasForeignKey(x => x.HouseTypeId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
