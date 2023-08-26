using BRR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRR.Infrastructure.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("Usuarios");
        
        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.FirstName)
            .HasColumnName("primer_nombre")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.SecondName)
            .HasColumnName("segundo_nombre")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("primer_apellido")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.SecondLastName)
            .HasColumnName("segundo_apellido")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("correo")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.Age)
            .HasColumnName("edad")
            .HasColumnType("TINYINT")
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasColumnName("genero")
            .HasColumnType("NVARCHAR(10)")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("telefono")
            .HasColumnType("NVARCHAR(8)")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.PictureUrl)
            .HasColumnName("foto_perfil_url")
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired(false);

        builder.Property(x => x.Password)
            .HasColumnName("contraseña")
            .HasColumnType("NVARCHAR(40)")
            .IsRequired();

        builder.Property(x => x.deleted)
            .HasColumnName("eliminado")
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.deleted);
    }
}
