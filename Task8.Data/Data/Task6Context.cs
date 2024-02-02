using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Task8.Data.Entity.Generated;

namespace Task8.Data.Data;

public partial class Task6Context : DbContext
{
    public Task6Context()
    {
    }

    public Task6Context(DbContextOptions<Task6Context> options)
: base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[ConnectionStringName.DbString.ToString()].ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__COURSES__71CB31DB72DA58AE");

            entity.ToTable("COURSES");

            entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__GROUPS__3EFEA3DE170855A6");

            entity.ToTable("GROUPS");

            entity.HasIndex(e => e.TeacherId, "IX_GROUPS_TeacherId");

            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Course).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__GROUPS__NAME__398D8EEE");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Groups).HasForeignKey(d => d.TeacherId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__STUDENTS__E69FE77B55722B59");

            entity.ToTable("STUDENTS");

            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__STUDENTS__LAST_N__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    private enum ConnectionStringName
    {
        DbString
    }
}
