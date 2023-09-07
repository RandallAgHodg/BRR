using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.ToTable("Agentes");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.AccountId)
            .HasColumnName("id_cuenta")
            .IsRequired(false);

        builder.HasMany(x => x.Clients)
            .WithOne(x => x.Agent)
            .HasForeignKey(x => x.AgentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Meetings)
            .WithOne(x => x.Agent)
            .HasForeignKey(x => x.AgentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Agents)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Navigation(x => x.Account)
            .AutoInclude();

        builder.HasQueryFilter(x => !x.Account.IsDeleted);
    }
}
