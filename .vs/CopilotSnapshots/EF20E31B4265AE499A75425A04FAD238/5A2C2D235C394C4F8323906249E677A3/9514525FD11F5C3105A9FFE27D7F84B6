using College.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Grade> Grades => Set<Grade>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(studentEntity => studentEntity.Id);
                entity.Property(studentEntity => studentEntity.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(studentEntity => studentEntity.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(studentEntity => studentEntity.CourseCode)
                    .HasMaxLength(20);
                
                entity.Ignore(studentEntity => studentEntity.Grades);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(courseEntity => courseEntity.Id);
                entity.Property(courseEntity => courseEntity.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(courseEntity => courseEntity.Code)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Ignore(courseEntity => courseEntity.Grades);
                entity.Ignore(courseEntity => courseEntity.Students);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(professorEntity => professorEntity.Id);
                entity.Property(professorEntity => professorEntity.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(professorEntity => professorEntity.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(professorEntity => professorEntity.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(professorEntity => professorEntity.Area)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Ignore(professorEntity => professorEntity.Courses);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(gradeEntity => gradeEntity.Id);
                entity.Property(gradeEntity => gradeEntity.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(gradeEntity => gradeEntity.Value)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");
                entity.Property(gradeEntity => gradeEntity.DateRecorded)
                    .IsRequired();
                entity.Property(gradeEntity => gradeEntity.StudentId)
                    .IsRequired();
                entity.Property(gradeEntity => gradeEntity.CourseCode)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
