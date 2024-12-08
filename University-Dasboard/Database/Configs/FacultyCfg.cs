using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Database.Configs
{
    public class FacultyCfg: IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(f => f.Id);
            builder.
                HasMany(f => f.Departments)
                .WithOne(d => d.Faculty)
                .HasForeignKey(d => d.FacultyId);

            builder.
                HasMany(f => f.Students)
                .WithOne(st => st.Faculty)
                .HasForeignKey(st => st.FacultyId);
        }
    }
}
