using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crud_Images.Models;

public partial class ImageContext : DbContext
{
    public ImageContext()
    {
    }

    public ImageContext(DbContextOptions<ImageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__7516F70C301E27CE");

            entity.Property(e => e.ImageName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
