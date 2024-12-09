using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Database.Configs
{
	public class ScheduleWeekCfg : IEntityTypeConfiguration<ScheduleWeek>
	{
		public void Configure(EntityTypeBuilder<ScheduleWeek> builder)
		{
			// Устанавливаем ключ
			builder.HasKey(s => s.Id);
		}
	}
}
