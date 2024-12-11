using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Database.Configs
{
	public class TeacherConstraintCfg : IEntityTypeConfiguration<TeacherConstraint>
	{
		public void Configure(EntityTypeBuilder<TeacherConstraint> builder)
		{
			builder.HasKey(tc => tc.Id);

			builder
				.HasOne(tc => tc.Teacher)
				.WithMany(t => t.Constraints)
				.HasForeignKey(tc => tc.TeacherId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasMany(tc => tc.DayConstraints)
				.WithOne(dc => dc.TeacherConstraint)
				.HasForeignKey(dc => dc.TeacherConstraintId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(tc => tc.Note)
				.HasMaxLength(200); // Ограничиваем длину описания
		}
	}
}
