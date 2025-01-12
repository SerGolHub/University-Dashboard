using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmTeachers;

namespace University_Dasboard.Controllers
{
    public class TeacherController
    {
        public static void LoadTeachers(DataGridView dgv, ref BindingList<TeacherViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();
            try
            {
                var teachers = ctx.Teacher.Include(t => t.Department).Include(t => t.Constraints)
                    .Select(t => new TeacherViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        PhoneNumber = t.PhoneNumber,
                        Email = t.Email,
                        HireDate = t.HireDate,
                        Degree = t.Degree,
                        Status = t.Status,
                        DepartmentId = t.DepartmentId,
                        DepartmentName = t.Department!.Name,
                    }).ToList();

                bindingList = new BindingList<TeacherViewModel>(teachers);
                dgv.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading teachers: {ex.Message}");
            }
        }

        public static async Task SaveTeachersAsync(
            List<TeacherViewModel> newTeacherList,
            List<TeacherViewModel> updatedTeacherList,
            List<TeacherViewModel> removedTeacherList)
        {
            using var ctx = new DatabaseContext();
            try
            {
                if (newTeacherList.Any())
                    await AddNewTeachersAsync(ctx, newTeacherList);

                if (updatedTeacherList.Any())
                    await UpdateExistingTeachersAsync(ctx, updatedTeacherList);

                if (removedTeacherList.Any())
                    await RemoveTeachersAsync(ctx, removedTeacherList);

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving teachers: {ex.Message}");
                throw;
            }
        }

        private static async Task AddNewTeachersAsync(DatabaseContext ctx, List<TeacherViewModel> newTeacherList)
        {
            var newTeachers = newTeacherList.Select(t => new Teacher
            {
                Id = t.Id,
                Name = t.Name,
                PhoneNumber = t.PhoneNumber,
                Email = t.Email,
                HireDate = t.HireDate,
                Degree = t.Degree,
                Status = t.Status,
                DepartmentId = t.DepartmentId,
            }).ToList();

            await ctx.Teacher.AddRangeAsync(newTeachers);
        }

        private static async Task UpdateExistingTeachersAsync(DatabaseContext ctx, List<TeacherViewModel> updatedTeacherList)
        {
            var teacherIds = updatedTeacherList.Select(t => t.Id).ToList();
            var existingTeachers = await ctx.Teacher
                .Include(t => t.Constraints)
                .Where(t => teacherIds.Contains(t.Id))
                .ToListAsync();

            foreach (var existingTeacher in existingTeachers)
            {
                var updatedTeacher = updatedTeacherList.First(t => t.Id == existingTeacher.Id);
                existingTeacher.Name = updatedTeacher.Name;
                existingTeacher.PhoneNumber = updatedTeacher.PhoneNumber;
                existingTeacher.Email = updatedTeacher.Email;
                existingTeacher.HireDate = updatedTeacher.HireDate;
                existingTeacher.Degree = updatedTeacher.Degree;
                existingTeacher.Status = updatedTeacher.Status;
                existingTeacher.DepartmentId = updatedTeacher.DepartmentId;
            }
        }

        private static async Task RemoveTeachersAsync(DatabaseContext ctx, List<TeacherViewModel> removedTeacherList)
        {
            var teacherIds = removedTeacherList.Select(t => t.Id).ToList();
            var teachersToRemove = await ctx.Teacher
                .Where(t => teacherIds.Contains(t.Id))
                .ToListAsync();

            ctx.Teacher.RemoveRange(teachersToRemove);
        }
    }
}
