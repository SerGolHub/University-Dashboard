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
	public class DayConstraintCfg : IEntityTypeConfiguration<DayConstraint>
	{
		public void Configure(EntityTypeBuilder<DayConstraint> builder)
		{
			builder.HasKey(dc => dc.Id);

			builder
				.HasOne(dc => dc.TeacherConstraint)
				.WithMany(tc => tc.DayConstraints)
				.HasForeignKey(dc => dc.TeacherConstraintId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(dc => dc.DayOfWeek)
				.IsRequired();
		}
	}
}
