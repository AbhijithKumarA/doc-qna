using DocQnA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DocQnA.Infrastructure.Persistence;

public class DocQnADbContext : DbContext
{
    public DocQnADbContext(DbContextOptions<DocQnADbContext> options) : base(options)
    {
    }

    public DbSet<DocumentChunk> DocumentChunks => Set<DocumentChunk>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("docqna");
        modelBuilder.HasPostgresExtension("vector");

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
