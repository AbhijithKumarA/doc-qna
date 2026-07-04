using DocQnA.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DocQnA.Api.Data;

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

        modelBuilder.Entity<DocumentChunk>(entity =>
        {
            entity.ToTable("document_chunks");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id");
            
            entity.Property(e => e.Content)
                .HasColumnName("content")
                .IsRequired();
            
            entity.Property(e => e.Embeddings)
                .HasColumnName("embeddings")
                .HasColumnType("vector(387)");
        });
    }
}
