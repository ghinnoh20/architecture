using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Domains;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace Repository.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<E8Log> E8Logs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC071B097DA8");

            entity.ToTable("Contact");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(user_name())");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Contact__Student__3D5E1FD2");
        });

        modelBuilder.Entity<E8Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__E8_Logs__3214EC27577F13E4");

            entity.ToTable("E8_Logs");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Employee)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.LogDescription).HasColumnName("Log_Description");
            entity.Property(e => e.Module).IsUnicode(false);
            entity.Property(e => e.StoreCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Terminal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tranno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TxDate)
                .HasColumnType("date")
                .HasColumnName("txDate");
            entity.Property(e => e.TxTime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("txTime");
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(user_name())");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
