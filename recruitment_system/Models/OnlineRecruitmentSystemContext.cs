using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using recruitment_system.Model;
using recruitment_system.Models;


#nullable disable

namespace recruitment_system.API.Models
{
    public partial class OnlineRecruitmentSystemContext : DbContext
    {
       

        public OnlineRecruitmentSystemContext()
        {
        }

        public OnlineRecruitmentSystemContext(DbContextOptions<OnlineRecruitmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jobseeker> Jobseekers { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=LAPTOP-72LMV1DP;Database=OnlineVehicleShowroom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Jobseeker>(entity =>
            {
                entity.ToTable("Jobseeker");

                entity.Property(e => e.JobseekerName).HasColumnName("JobseekerName");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.city)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.education)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.skills)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("Employer");

                entity.Property(e => e.CompanyName).HasColumnName("CompanyName");

                entity.Property(e => e.EmployerClients)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurentOpenings)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}