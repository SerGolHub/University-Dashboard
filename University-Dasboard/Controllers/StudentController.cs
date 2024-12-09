using Database;
using static University_Dasboard.FrmStudents;
using System.ComponentModel;
using University_Dasboard.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace University_Dasboard.Controllers
{
    public class StudentController
    {
        public static void LoadStudents(
            DataGridView dgv,
            ref BindingList<StudentViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();
            var students = ctx.Student
            .Include(s => s.Group!)
            .ThenInclude(g => g.Direction)
            .ThenInclude(dir => dir!.Department) // dir! означает, что dir не может быть null
            .ThenInclude(dep => dep!.Faculty)
            .Select(s => new StudentViewModel
            {
                Id = s.Id,
                Name = s.Name,
                EnrollmentDate = s.EnrollmentDate,
                EnrollmentNumber = s.EnrollmentNumber,
                IsExcellentStudent = s.IsExcellentStudent,
                CourseNumber = s.CourseNumber,
                GroupId = s.GroupId,
                GroupName = s.Group!.Name
            })
            .ToList();
            
            bindingList = new BindingList<StudentViewModel>(students);
            dgv.DataSource = bindingList;
        }

        public static async Task SaveStudentsAsync(
                List<StudentViewModel> newStudentList,
                List<StudentViewModel> updatedStudentList,
                List<StudentViewModel> removedStudentList)
        {
            using var ctx = new DatabaseContext();

            await AddNewStudentsAsync(ctx, newStudentList);
            await UpdateExistingStudentsAsync(ctx, updatedStudentList);
            await RemoveStudentsAsync(ctx, removedStudentList);

            await ctx.SaveChangesAsync();
        }

        private static async Task AddNewStudentsAsync(
            DatabaseContext ctx,
            List<StudentViewModel> newStudentList)
        {
            if (newStudentList.Count < 1)
            {
                return;
            }
            var newStudents = newStudentList.Select(s => new Student
            {
                Id = Guid.NewGuid(),
                Name = s.Name,
                EnrollmentDate = s.EnrollmentDate,
                EnrollmentNumber = s.EnrollmentNumber,
                IsExcellentStudent = s.IsExcellentStudent,
                CourseNumber = s.CourseNumber,
                GroupId = s.GroupId
            }).ToList();

            await ctx.Student.AddRangeAsync(newStudents);
        }

        private static async Task UpdateExistingStudentsAsync(
            DatabaseContext ctx,
            List<StudentViewModel> updatedStudents)
        {
            if (updatedStudents.Count < 1)
            {
                return;
            }
            var updatedIds = updatedStudents.Select(s => s.Id).ToList();
            var existingStudents = await ctx.Student
                .Where(s => updatedIds.Contains(s.Id))
                .ToListAsync();

            foreach (var existingStudent in existingStudents)
            {
                var updatedStudent = updatedStudents.First(s => s.Id == existingStudent.Id);
                existingStudent.Name = updatedStudent.Name;
                existingStudent.EnrollmentDate = updatedStudent.EnrollmentDate;
                existingStudent.EnrollmentNumber = updatedStudent.EnrollmentNumber;
                existingStudent.GroupId = updatedStudent.GroupId;
            }
        }

        private static async Task RemoveStudentsAsync(
            DatabaseContext ctx, List<StudentViewModel> removedStudents)
        {
            if (removedStudents.Count < 1)
            {
                return;
            }
            var removedIds = removedStudents.Select(s => s.Id).ToList();
            var studentsToRemove = await ctx.Student
                .Where(s => removedIds.Contains(s.Id))
                .ToListAsync();

            ctx.Student.RemoveRange(studentsToRemove);
        }
    }
}
