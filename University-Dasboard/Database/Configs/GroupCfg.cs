using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class GroupCfg : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);
        builder.
            HasOne(g => g.Direction)
            .WithMany(dir => dir.Groups)
            .HasForeignKey(g => g.DirectionId);

        builder.
            HasMany(g => g.Students)
            .WithOne(st => st.Group)
            .HasForeignKey(st => st.GroupId);

    }
}
