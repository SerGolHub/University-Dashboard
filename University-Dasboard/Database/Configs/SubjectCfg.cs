using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class SubjectCfg : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(dis => dis.Id);
        builder.
            HasOne(dis => dis.Teacher)
            .WithMany(t => t.Subjects)
            .HasForeignKey(dis => dis.TeacherId);

        builder.
            HasMany(dis => dis.Marks)
            .WithOne(m => m.Subject)
            .HasForeignKey(m => m.SubjectId);

        builder.
            HasOne(dis => dis.Direction)
            .WithMany(dir => dir.Subjects);
    }
}
