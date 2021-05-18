using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext()
        {
        }

        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Executor> Executor { get; set; }
        public virtual DbSet<ExecutorField> ExecutorField { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Taskofproject> Taskofproject { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database =TaskTracker; Username = postgres; Password =password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.Commentid)
                    .HasName("comments_pkey");

                entity.ToTable("comments");

                entity.Property(e => e.Commentid).HasColumnName("commentid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasColumnName("mark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Taskid).HasColumnName("taskid");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("customeridfk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Taskid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("taskidfk");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("useridfk");
            });

            modelBuilder.Entity<Executor>(entity =>
            {
                entity.ToTable("executor");

                entity.Property(e => e.Executorid).HasColumnName("executorid");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Executor)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("useridfk");
            });

            modelBuilder.Entity<ExecutorField>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("executor_field");

                entity.Property(e => e.Executorid).HasColumnName("executorid");

                entity.Property(e => e.Fieldid).HasColumnName("fieldid");

                entity.HasOne(d => d.Executor)
                    .WithMany()
                    .HasForeignKey(d => d.Executorid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("executoridfk");

                entity.HasOne(d => d.Field)
                    .WithMany()
                    .HasForeignKey(d => d.Fieldid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fieldidfk");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("field");

                entity.Property(e => e.Fieldid).HasColumnName("fieldid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("customeridfk");
            });

            modelBuilder.Entity<Taskofproject>(entity =>
            {
                entity.ToTable("taskofproject");

                entity.Property(e => e.Taskofprojectid).HasColumnName("taskofprojectid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Taskid).HasColumnName("taskid");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Taskofproject)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("projectidfk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Taskofproject)
                    .HasForeignKey(d => d.Taskid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("taskidfk");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.Taskid)
                    .HasName("tasks_pkey");

                entity.ToTable("tasks");

                entity.Property(e => e.Taskid).HasColumnName("taskid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(255);

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255);

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Role).HasColumnName("role");
            });

            modelBuilder.HasSequence("forUser");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
