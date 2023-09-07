using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class HouseConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("Inmuebles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("titulo");

        builder.Property(x => x.Floors)
            .IsRequired()
            .HasColumnName("pisos");

        builder.Property(x => x.Area)
            .IsRequired()
            .HasColumnName("area");

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("precio");

        builder.Property(x => x.Bathrooms)
            .IsRequired()
            .HasColumnName("baños");

        builder.Property(x => x.Livingrooms)
            .IsRequired()
            .HasColumnName("habitaciones");

        builder.Property(x => x.Bedrooms)
            .IsRequired()
            .HasColumnName("dormitorios");

        builder.Property(x => x.Discount)
            .IsRequired()
            .HasColumnName("descuento");

        builder.Property(x => x.HasBalcony)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("balcon");

        builder.Property(x => x.HasPool)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("piscina");

        builder.Property(x => x.PictureUrl)
            .IsRequired()
            .HasColumnName("foto_url");

        builder.Property(x => x.VideoUrl)
            .IsRequired()
            .HasColumnName("video_url");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false)
            .HasColumnName("eliminado");

        builder.Property(x => x.ClientId)
            .IsRequired()
            .HasColumnName("id_cliente");

        builder.HasOne(x => x.Client)
            .WithMany()
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IsSold)
            .HasColumnName("vendida")
            .HasDefaultValue(false);

        builder.Property(x => x.IsAccepted)
            .HasColumnName("aprobada")
            .HasDefaultValue(false);

        builder.Property(x => x.IsRejected)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("rechazada");

        builder.Property(x => x.HouseTypeId)
            .HasColumnName("id_tipo")
            .IsRequired(true);

        builder.HasOne(x => x.HouseType)
            .WithMany(x => x.Houses)
            .HasForeignKey(x => x.HouseTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Meetings)
            .WithOne(x => x.House)
            .HasForeignKey(x => x.HouseId)
            .OnDelete(DeleteBehavior.NoAction); 

        builder.HasQueryFilter(x => !x.IsDeleted && !x.IsRejected);
    }
}
