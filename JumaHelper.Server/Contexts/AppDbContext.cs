using System.Reflection;
using JumaHelper.Server.Models;
using JumaHelper.Server.Models.DbSets;

namespace JumaHelper.Server.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DuaRequest> DuaRequests { get; set; }

    public DbSet<DuaRequestType> DuaRequestTypes { get; set; }

    public DbSet<DuaRequestOwner> DuaRequestOwners { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: EntityBase, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
                ((EntityBase)entityEntry.Entity).CreatedAt = DateTime.Now;
            else
                Entry((EntityBase)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
            
            if (entityEntry.State == EntityState.Modified)
                ((EntityBase)entityEntry.Entity).ModifiedAt = DateTime.Now;
            else
                Entry((EntityBase)entityEntry.Entity).Property(p => p.ModifiedAt).IsModified = false;
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}