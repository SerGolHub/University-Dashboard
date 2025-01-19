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
