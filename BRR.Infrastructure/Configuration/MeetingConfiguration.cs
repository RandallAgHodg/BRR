using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.ToTable("Reunion");

        builder.HasKey(x => new { x.HouseId, x.AgentId, x.ClientId });

        builder
            .Property(x => x.ClientId)
            .HasColumnName("id_cliente");

        builder.Property(x => x.Description)
            .HasColumnName("descripcion");

        builder
            .Property(x => x.AgentId)
            .HasColumnName("id_agente");

        builder.Property(x => x.HouseId)
            .HasColumnName("id_inmueble");

        builder.Property(x => x.Date)
            .HasColumnName("fecha_reunion");

        builder.HasOne(x => x.Agent)
            .WithMany(x => x.Meetings)
            .HasForeignKey(x => x.AgentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Meetings)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.House)
            .WithMany(x => x.Meetings)
            .HasForeignKey(x => x.HouseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
