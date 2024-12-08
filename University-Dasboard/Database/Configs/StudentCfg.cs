using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class StudentCfg : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(st => st.Id);
        builder.
            HasOne(st => st.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(st => st.GroupId);

        builder.
            HasMany(st => st.Marks)
            .WithOne(m => m.Student)
            .HasForeignKey(m => m.StudentId);

        builder.
            HasOne(st => st.Faculty)
            .WithMany(f => f.Students)
            .HasForeignKey(st => st.FacultyId);
    }
}
