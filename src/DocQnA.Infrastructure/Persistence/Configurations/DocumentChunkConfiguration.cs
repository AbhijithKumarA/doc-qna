using DocQnA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pgvector;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocQnA.Infrastructure.Persistence.Configurations;

public class DocumentChunkConfiguration : IEntityTypeConfiguration<DocumentChunk>
{
    public void Configure(EntityTypeBuilder<DocumentChunk> builder)
    {
        builder.ToTable("document_chunks");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.Content)
            .HasColumnName("content")
            .IsRequired();
        
        builder.Property(e => e.Embeddings)
            .HasColumnName("embeddings")
            .HasConversion(
                embedding => new Vector(embedding),
                vector => vector.ToArray())
            .HasColumnType("vector(768)");
    }
}
