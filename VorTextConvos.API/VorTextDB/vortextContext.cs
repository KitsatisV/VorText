using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VorTextConvos.API.VorTextDB
{
    public partial class vortextContext : DbContext
    {
        public vortextContext()
        {
        }

        public vortextContext(DbContextOptions<vortextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserPass> UserPasses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=vortextmysqlserver.mysql.database.azure.com;userid=adminvortext;password=Vrtxt123;database=vortext;sslmode=Required;sslca=VTDigiCertGlobalRootCA.crt.pem;tlsversion=\"TLS 1.2\"", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PassId)
                    .HasName("PRIMARY");

                entity.ToTable("passwords");

                entity.HasIndex(e => e.PassId, "idPasswords_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PassId).HasColumnName("passID");

                entity.Property(e => e.Password1)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username, "Username_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UsersID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserPass>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PassId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_pass");

                entity.HasIndex(e => e.UserId, "UserID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PassId, "passID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.PassId).HasColumnName("passID");

                entity.HasOne(d => d.Pass)
                    .WithOne(p => p.UserPass)
                    .HasForeignKey<UserPass>(d => d.PassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("passID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserPass)
                    .HasForeignKey<UserPass>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
