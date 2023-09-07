using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .ToTable("Clientes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AgentId)
            .HasColumnName("id_agente")
            .IsRequired(false);

        builder.Property(x => x.AccountId)
            .HasColumnName("id_cuenta");

        builder.HasOne(x => x.Agent)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.AgentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Meetings)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(x => x.Account)
            .AutoInclude();

        builder.HasQueryFilter(x => !x.Account.IsDeleted);
    }
}
