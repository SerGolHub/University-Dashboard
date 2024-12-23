using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class DepartmentCfg : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(dep => dep.Id);
        builder.
            HasOne(dep => dep.Faculty)
            .WithMany(f => f.Departments);

        builder.
            HasMany(dep => dep.Directions)
            .WithOne(dir => dir.Department)
            .HasForeignKey(dir => dir.DepartmentId);

        builder.
            HasMany(dep => dep.Teachers)
            .WithOne(t => t.Department)
            .HasForeignKey(t => t.DepartmentId);
    }
}
