using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversityPO.Domain.Models;

namespace UniversityPO.Domain
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicDegree> AcademicDegree { get; set; }
        public virtual DbSet<AcademicPerfomance> AcademicPerfomance { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<DayOfWeekId> DayOfWeekId { get; set; }
        public virtual DbSet<DeliveryType> DeliveryType { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<LessonType> LessonType { get; set; }
        public virtual DbSet<NumberLesson> NumberLesson { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=University");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AcademicDegree>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<AcademicPerfomance>(entity =>
            {
                entity.Property(e => e.DateReceiptRating).HasColumnType("date");

                entity.Property(e => e.StudentId).HasMaxLength(20);

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.AcademicPerfomance)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AcademicPerfomance_Discipline");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AcademicPerfomance)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AcademicPerfomance_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AcademicPerfomance)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_AcademicPerfomance_Teacher");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Corpus).HasMaxLength(50);

                entity.Property(e => e.NumberRoom).HasMaxLength(10);
            });

            modelBuilder.Entity<DayOfWeekId>(entity =>
            {
                entity.HasKey(e => e.DayOfWeekId1);

                entity.Property(e => e.DayOfWeekId1).HasColumnName("DayOfWeekId");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<DeliveryType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.DeliveryType)
                    .WithMany(p => p.Discipline)
                    .HasForeignKey(d => d.DeliveryTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Discipline_DeliveryType");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.DatePublic).HasColumnType("date");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasMaxLength(10);

                entity.Property(e => e.DateReceipt).HasColumnType("date");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Group_Faculty");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Group_Specialty");
            });

            modelBuilder.Entity<LessonType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<NumberLesson>(entity =>
            {
                entity.Property(e => e.EndLessonDate).HasColumnType("date");

                entity.Property(e => e.StartLessonDate).HasColumnType("date");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.GroupId).HasMaxLength(10);

                entity.Property(e => e.ScheduleId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Classroom)
                    .WithMany()
                    .HasForeignKey(d => d.ClassroomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_Classroom");

                entity.HasOne(d => d.DayOfWeek)
                    .WithMany()
                    .HasForeignKey(d => d.DayOfWeekId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_DayOfWeekId");

                entity.HasOne(d => d.Discipline)
                    .WithMany()
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_Discipline");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_Group");

                entity.HasOne(d => d.LessonType)
                    .WithMany()
                    .HasForeignKey(d => d.LessonTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_LessonType");

                entity.HasOne(d => d.NumberLesson)
                    .WithMany()
                    .HasForeignKey(d => d.NumberLessonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Schedule_NumberLesson");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Schedule_Teacher");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.GroupId).HasMaxLength(10);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_Group");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.HasOne(d => d.AcademicDegree)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.AcademicDegreeId)
                    .HasConstraintName("FK_Teacher_AcademicDegree");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Teacher_Discipline");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Teacher_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
