using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Ksacity> Ksacities { get; set; }
        public virtual DbSet<RequestService> RequestServices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersComment> UsersComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql5074.site4now.net;Database=DB_A69E7D_TamauzFurneture;User Id=DB_A69E7D_TamauzFurneture_admin;Password=TamauzFurneture123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnounceContent).HasColumnName("announceContent");

                entity.Property(e => e.AnnounceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("announceDate");

                entity.Property(e => e.AnnounceExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("announceExpireDate");

                entity.Property(e => e.AnnounceHeader).HasColumnName("announceHeader");

                entity.Property(e => e.AnnouncePhotoPath).HasColumnName("announcePhotoPath");
            });

            modelBuilder.Entity<Ksacity>(entity =>
            {
                entity.ToTable("KSACities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RequestService>(entity =>
            {
                entity.ToTable("RequestService");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityFromId).HasColumnName("cityFromId");

                entity.Property(e => e.CityToId).HasColumnName("cityToId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .HasColumnName("fullName");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("requestDate");

                entity.Property(e => e.RequestText).HasColumnName("requestText");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.HasOne(d => d.CityFrom)
                    .WithMany(p => p.RequestServiceCityFroms)
                    .HasForeignKey(d => d.CityFromId)
                    .HasConstraintName("FK_RequestService_KSACities");

                entity.HasOne(d => d.CityTo)
                    .WithMany(p => p.RequestServiceCityTos)
                    .HasForeignKey(d => d.CityToId)
                    .HasConstraintName("FK_RequestService_KSACities1");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RequestServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_RequestService_Services");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ServiceDescription).HasColumnName("serviceDescription");

                entity.Property(e => e.ServiceName).HasColumnName("serviceName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<UsersComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("date")
                    .HasColumnName("commentDate");

                entity.Property(e => e.CommentText).HasColumnName("commentText");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RequestServiceId).HasColumnName("requestServiceId");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(200)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserFullName)
                    .HasMaxLength(500)
                    .HasColumnName("userFullName");

                entity.HasOne(d => d.RequestService)
                    .WithMany(p => p.UsersComments)
                    .HasForeignKey(d => d.RequestServiceId)
                    .HasConstraintName("FK_UsersComments_RequestService");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
