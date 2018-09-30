using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetCoreVue.DB.EFModels
{
    public partial class EFContent : DbContext
    {
        public EFContent()
        {
        }

        public EFContent(DbContextOptions<EFContent> options)
            : base(options)
        {
        }

        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=111111;Database=corevue");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>(entity =>
            {
                entity.ToTable("node");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Com).HasColumnType("varchar(300)");

                entity.Property(e => e.DisplayName).HasColumnType("varchar(100)");

                entity.Property(e => e.Icon).HasColumnType("varchar(100)");

                entity.Property(e => e.InsTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name).HasColumnType("varchar(200)");

                entity.Property(e => e.Path).HasColumnType("varchar(300)");

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userinfo");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LoginName).HasColumnType("varchar(200)");

                entity.Property(e => e.Password).HasColumnType("varchar(200)");

                entity.Property(e => e.UserName).HasColumnType("varchar(200)");
            });
        }
    }
}
