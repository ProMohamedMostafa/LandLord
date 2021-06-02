using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GenieLandLoardSolution.Models
{
    public partial class GenieDBlandLoardContext : DbContext
    {
        public GenieDBlandLoardContext()
        {
        }

        public GenieDBlandLoardContext(DbContextOptions<GenieDBlandLoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbLandLoard> TbLandLoards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=GenieDBlandLoard;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbLandLoard>(entity =>
            {
                entity.ToTable("tbLandLoard");

                entity.HasIndex(e => e.Name, "UQ__tbLandLo__737584F6DD37B7C2")
                    .IsUnique();

                entity.HasIndex(e => e.Domain, "UQ__tbLandLo__FD349E5384C96225")
                    .IsUnique();

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
