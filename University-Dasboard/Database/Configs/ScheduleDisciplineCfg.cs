using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Database.Configs
{
	public class ScheduleDisciplineCfg : IEntityTypeConfiguration<ScheduleDiscipline>
	{
		public void Configure(EntityTypeBuilder<ScheduleDiscipline> builder)
		{
			// Установка первичного ключа
			builder.HasKey(dir => dir.Id);

			// Настройка отношения Discipline
			builder
				.HasOne(sd => sd.Subject)
				.WithMany(d => d.ScheduleDisciplines)
				.HasForeignKey(sd => sd.SubjectId)
				.OnDelete(DeleteBehavior.Cascade);

			// Настройка отношения Group
			builder
				.HasOne(sd => sd.Group)
				.WithMany(g => g.ScheduleDisciplines)
				.HasForeignKey(sd => sd.GroupId)
				.OnDelete(DeleteBehavior.Cascade);

			// Настройка отношения ScheduleWeek
			builder
				.HasOne(sd => sd.ScheduleWeek)
				.WithMany(sw => sw.ScheduleDisciplines)
				.HasForeignKey(sd => sd.ScheduleWeekId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
