namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;

public class StudentSystemContext : DbContext
{
	public StudentSystemContext()
	{
	}

	public StudentSystemContext(DbContextOptions options) : base (options)
	{
	}	

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.CONNECTION_STRING);
		}
		base.OnConfiguring(optionsBuilder);
	}

	public DbSet<Student> Students { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Resource> Resources { get; set; }
	public DbSet<Homework> Homeworks { get; set; }
	public DbSet<StudentCourse> StudentsCourses { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Student>(entity =>
		{
			entity.HasKey(s => s.StudentId);
			entity
				.Property(s => s.Name)
				.HasMaxLength(ValidationConstants.STUDENT_NAME_MAX_LENGTH);
			entity
				.Property(s => s.PhoneNumber)
				.HasMaxLength(ValidationConstants.STUDENT_PHONENUMBER_MAX_LENGTH)
				.IsUnicode(false)
				.IsRequired(false);
			entity
				.Property(s => s.Birthday)
				.IsRequired(false);
		});

		modelBuilder.Entity<Course>(entity =>
		{
			entity.HasKey(c => c.CourseId);
			entity
				.Property(c => c.Name)
				.HasMaxLength(ValidationConstants.COURSE_NAME_MAX_LENGTH)
				.IsUnicode();
			entity
				.Property(c => c.Description)
				.HasMaxLength(ValidationConstants.COURSE_DESCRIPTION_MAX_LENGTH)
				.IsRequired(false);
		});

		modelBuilder.Entity<Resource>(entity =>
		{
			entity.HasKey(r => r.ResourceId);
			entity
				.Property(r => r.Name)
				.HasMaxLength(ValidationConstants.RESOURCE_NAME_MAX_LENGTH)
				.IsUnicode();
			entity
				.Property(r => r.Url)
				.HasMaxLength(ValidationConstants.RESOURCE_URL_MAX_LENGTH)
				.IsUnicode(false);
			entity
				.HasOne(r => r.Course)
				.WithMany(r => r.Resources)
				.HasForeignKey(r => r.CourseId);

		});

		modelBuilder.Entity<Homework>(entity =>
		{
			entity.HasKey(h => h.HomeworkId);
			entity
				.Property(h => h.Content)
				.HasMaxLength(ValidationConstants.HOMEWORK_CONTENT_MAX_LENGTH)
				.IsUnicode(false);
			entity
				.HasOne(h => h.Student)
				.WithMany(h => h.Homeworks)
				.HasForeignKey(h => h.StudentId);
			entity
				.HasOne(h => h.Course)
				.WithMany(h => h.Homeworks)
				.HasForeignKey(h => h.CourseId);
		});

		modelBuilder.Entity<StudentCourse>(entity =>
		{
			entity.HasKey(sc => new { sc.StudentId, sc.CourseId});
			entity
				.HasOne(sc => sc.Student)
				.WithMany(s => s.StudentsCourses)
				.HasForeignKey(sc => sc.StudentId);
			entity
				.HasOne(sc => sc.Course)
				.WithMany(c => c.StudentsCourses)
				.HasForeignKey(sc => sc.CourseId);
		});
	}
}