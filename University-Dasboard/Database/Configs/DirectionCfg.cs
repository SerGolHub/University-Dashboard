using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class DirectionCfg : IEntityTypeConfiguration<Direction>
{
    public void Configure(EntityTypeBuilder<Direction> builder)
    {
        builder.HasKey(dir => dir.Id);
        builder.
            HasOne(dir => dir.Department)
            .WithMany(dep => dep.Directions)
            .HasForeignKey(dir => dir.DepartmentId);

        builder.
            HasMany(dir => dir.Groups)
            .WithOne(g => g.Direction)
            .HasForeignKey(g => g.DirectionId);
    }
}
