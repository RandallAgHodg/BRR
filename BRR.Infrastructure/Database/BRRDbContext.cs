using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BRR.Infrastructure.Database;

public sealed class BRRDbContext : IdentityDbContext<Account, Role, int> { 
    public BRRDbContext(DbContextOptions options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BRRDbContext).Assembly);
    }
}