using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class MarksCfg : IEntityTypeConfiguration<Marks>
{
    public void Configure(EntityTypeBuilder<Marks> builder)
    {
        builder.HasKey(m => m.Id);
        builder.
            HasOne(m => m.Student)
            .WithMany(st => st.Marks)
            .HasForeignKey(m => m.StudentId);

        builder.
            HasOne(m => m.Subject)
            .WithMany(sub => sub.Marks)
            .HasForeignKey(m => m.SubjectId);
    }
}