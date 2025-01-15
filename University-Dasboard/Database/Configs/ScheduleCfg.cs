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
    public class ScheduleCfg : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            // Установка первичного ключа
            builder.HasKey(s => s.Id);

            // Настройка связи "один-ко-многим" между Schedule и ScheduleDiscipline
            builder
                .HasMany(s => s.ScheduleDisciplines) // Одно расписание может включать несколько расчётовок
                .WithOne(sd => sd.Schedule) // Каждая расчётовка ссылается на одно расписание
                .HasForeignKey(sd => sd.ScheduleId) // Внешний ключ в ScheduleDiscipline
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление

            // Ограничения для полей времени
            builder
                .Property(s => s.timeBegin)
                .IsRequired();

            builder
                .Property(s => s.timeEnd)
                .IsRequired();
        }
    }
}
