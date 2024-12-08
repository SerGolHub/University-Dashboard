﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Dasboard.Database.Models;

public class TeacherCfg : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        builder.
            HasOne(t => t.Department)
            .WithMany(dep => dep.Teachers)
            .HasForeignKey(t => t.DeparatmentId);

        builder.
            HasMany(t => t.Subjects)
            .WithOne(sub => sub.Teacher)
            .HasForeignKey(sub => sub.TeacherId);
    }
}
