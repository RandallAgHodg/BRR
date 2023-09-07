using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Cuentas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
         .HasColumnName("nombre")
         .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("apellido")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("telefono")
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("contraseña")
            .IsRequired();

        builder.Property(x => x.PictureUrl)
            .HasColumnName("foto_url")
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasColumnName("eliminado")
            .HasDefaultValue(false);

        builder.Property(x => x.RoleId)
            .HasColumnName("id_rol")
            .IsRequired();

        builder.Property(x => x.Token)
            .HasColumnName("token")
            .HasDefaultValue($"{Guid.NewGuid()}{DateTime.UtcNow}");

        builder.Property(x => x.IsConfirmed)
            .HasColumnName("confirmado")
            .HasDefaultValue(false);

        builder.Navigation(x => x.Role)
            .AutoInclude();

        builder.HasMany(x => x.Clients)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Agents)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
