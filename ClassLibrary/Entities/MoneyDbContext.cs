using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Entities;

public partial class MoneyDbContext : DbContext
{
    public MoneyDbContext()
    {
    }
   

    public MoneyDbContext(DbContextOptions<MoneyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MoneyDetail> MoneyDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-9V32A8G2\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MoneyDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MoneyDet__3214EC072775B7EE");

            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.RecieverName).HasMaxLength(50);
            entity.Property(e => e.SenderName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
