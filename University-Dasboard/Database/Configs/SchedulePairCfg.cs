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
    public class SchedulePairCfg : IEntityTypeConfiguration<SchedulePair>
    {
        public void Configure(EntityTypeBuilder<SchedulePair> builder)
        {
            // Установка первичного ключа
            builder.HasKey(sp => sp.Id);

            // Настройка отношений с ScheduleDiscipline
            builder
                .HasOne(sp => sp.ScheduleDiscipline)
                .WithMany(sd => sd.SchedulePairs) // Добавить свойство SchedulePairs в ScheduleDiscipline
                .HasForeignKey(sp => sp.ScheduleDisciplineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
