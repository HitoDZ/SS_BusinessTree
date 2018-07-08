using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SqlInteraction
{
    public partial class SS2018Context : DbContext
    {
        public SS2018Context()
        {
        }

        public SS2018Context(DbContextOptions<SS2018Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyValue> PropertyValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LENOVO-PC;Database=SS2018;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Levels_ParentId");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Properties_LevelId");
            });

            modelBuilder.Entity<PropertyValue>(entity =>
            {
                entity.Property(e => e.PropertyValueId).ValueGeneratedOnAdd();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.PropertyValues)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyValues_LevelId");

                entity.HasOne(d => d.ParentPropertyValue)
                    .WithMany(p => p.InverseParentPropertyValue)
                    .HasForeignKey(d => d.ParentPropertyValueId)
                    .HasConstraintName("FK_PropertyValues_ParentPropertyValueId");

                entity.HasOne(d => d.PropertyValueNavigation)
                    .WithOne(p => p.PropertyValue)
                    .HasForeignKey<PropertyValue>(d => d.PropertyValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyValues_PropertyId");
            });
        }
    }
}
