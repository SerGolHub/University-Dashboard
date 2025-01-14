using Database;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Enums;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmGroups;

namespace University_Dasboard
{
	public partial class FrmTeachers : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		// Вспомогательные ViewModel для отображения данных
		public class TeacherViewModel
		{
			public Guid Id { get; set; }

			public string Name { get; set; } = string.Empty;

			public string PhoneNumber { get; set; } = string.Empty;

			public string Email { get; set; } = string.Empty;

			public DateTime HireDate { get; set; }

			public string Degree { get; set; } = string.Empty;

			public string Status { get; set; } = string.Empty;

			public Guid DepartmentId { get; set; }

			public string DepartmentName { get; set; } = string.Empty;

			public List<TeacherConstraintViewModel> Constraints { get; set; } = new();
		}

		public class TeacherConstraintViewModel
		{
			public Guid Id { get; set; }

			public Guid TeacherId { get; set; }
			public Teacher Teacher { get; set; } = null!;

			public DayOfWeek DayOfWeek { get; set; }

			public TimeSpan StartTime { get; set; }
			public TimeSpan EndTime { get; set; }

			public string Note { get; set; } = string.Empty;
		}

		public FrmTeachers()
		{
			InitializeComponent();
			PopulateCheckedListBoxWithDaysOfWeek(checkedListBoxDays);
			LoadData();
		}

		private BindingList<TeacherViewModel> teachers = [];
		private List<TeacherViewModel> newTeacherList = [];
		private List<TeacherViewModel> updatedTeacherList = [];
		private List<TeacherViewModel> removedTeacherList = [];
		private Department? selectedDepartment;
		private Teacher? selectedTeacher;


		private void LoadData()
		{
			try
			{
				using var ctx = new DatabaseContext();

				TeacherController.LoadTeachers(dgvTeacherList, ref teachers);
				DataGridViewHelper.HideColumns(dgvTeacherList,
					["Id", "DepartmentId"]);
				LoadComboboxData(ctx);


				logger.Info("Направления были успешно загружены");

				// Загрузка значений перечисления Degree в ComboBox
				cbDegree.DataSource = Enum.GetValues(typeof(DegreeTeachers));

				cbStatus.DataSource = Enum.GetValues(typeof(StatusTeacher)).Cast<StatusTeacher>()
					.Select(e => new { Value = e, DisplayName = GetEnumDisplayName(e) }).ToList();

				cbStatus.DisplayMember = "DisplayName";
				cbStatus.ValueMember = "Value";

				logger.Info("Список преподавателей успешно загружен.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
				logger.Error(ex, "Ошибка при загрузке данных преподавателей.");
			}
		}

		private void LoadComboboxData(DatabaseContext ctx)
		{
			var departments = ctx.Department.ToList();

			ComboboxHelper.LoadCombobox(
				departments,
				comboBox: cbDepartment);

			var teachers = ctx.Teacher
				.Select(t => new { t.Id, t.Name })
				.ToList();
		}

		private void ClearTempLists()
		{
			newTeacherList.Clear();
			updatedTeacherList.Clear();
			removedTeacherList.Clear();

			logger.Info("Временные списки очищены.");
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string fullName = tbFullName.Text;

			string phoneNumber = tbPhoneNumber.Text;

			string email = tbEmail.Text;

			if (string.IsNullOrWhiteSpace(fullName))
			{
				MessageBox.Show("Введите ФИО преподавателя.");
				logger.Warn("Попытка добавить преподавателя без имени.");
				return;
			}

			// Получение выбранного значения из ComboBox
			if (cbDegree.SelectedItem == null)
			{
				MessageBox.Show("Выберите степень преподавателя.");
				logger.Warn("Попытка добавить преподавателя без выбранной степени.");
				return;
			}

			// Проверка мобильного телефона
			if (string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(phoneNumber, "^(\\+7|8)[0-9]{10}$"))
			{
				logger.Warn("Попытка добавить мобильный телефон не удалась.");
				MessageBox.Show("Номер телефона введен неверно. Он должен начинаться с '+7' или '8' и содержать 11 цифр.");
				return;
			}

			// Проверка электронного адреса
			if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
			{
				logger.Warn("Попытка добавить почту не удалась.");
				MessageBox.Show("Электронный адрес введен неверно. Он должен быть в формате 'example@example.com'.");
				return;
			}

			if (selectedDepartment == null)
			{
				logger.Warn("Попытка выбора кафедры не удалась.");
				MessageBox.Show("Пользователь не выбрал кафедру");
				return;
			}

			var newTeacher = new TeacherViewModel
			{
				Id = Guid.NewGuid(),
				Name = fullName,
				PhoneNumber = tbPhoneNumber.Text,
				Email = tbEmail.Text,
				HireDate = dtpHireDate.Value.ToUniversalTime(),
				Degree = cbDegree.Text,
				Status = cbStatus.Text,
				DepartmentId = selectedDepartment!.Id,
				DepartmentName = selectedDepartment.Name
			};

			newTeacherList.Add(newTeacher);
			teachers.Add(newTeacher);

			logger.Info("Преподаватель добавлен в список на сохранение.");
		}

		async private void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = true;

			try
			{
				await TeacherController.SaveTeachersAsync(
					newTeacherList,
					updatedTeacherList,
					removedTeacherList);
				ClearTempLists();

				lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
				lbDbSaveResult.Text = "Данные успешно сохранены.";
				logger.Info("Данные преподавателей успешно сохранены.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
				logger.Error(ex, "Ошибка сохранения данных преподавателей.");
			}
			finally
			{
				await Task.Delay(3000);
				lbDbSaveResult.Visible = false;
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvTeacherList.CurrentRow == null)
			{
				MessageBox.Show("Выберите преподавателя для удаления.");
				logger.Warn("Попытка удалить преподавателя без выбора строки.");
				return;
			}

			var id = (Guid)dgvTeacherList.CurrentRow.Cells["Id"].Value;
			var teacherToDelete = teachers.FirstOrDefault(t => t.Id == id);

			if (teacherToDelete != null)
			{
				teachers.Remove(teacherToDelete);
				newTeacherList.Remove(teacherToDelete);
				updatedTeacherList.Remove(teacherToDelete);
				removedTeacherList.Add(teacherToDelete);

				logger.Info($"Преподаватель с ID {id} добавлен в список на удаление.");
			}
		}

		private void dgvTeacherList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			var editedRow = dgvTeacherList.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			TeacherViewModel updatedTeacher = teachers.First(t => t.Id == id);
			updatedTeacherList.Add(updatedTeacher);

			logger.Info($"Преподаватель с ID {updatedTeacher.Id} добавлен в список на обновление.");
		}

		private void dgvTeacherList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
		}

		private void btnAddConstraint_Click(object sender, EventArgs e)
		{
			if (comboBoxTeachers.SelectedValue == null)
			{
				MessageBox.Show("Выберите преподавателя для добавления ограничения.");
				return;
			}

			var selectedDays = checkedListBoxDays.CheckedItems.Cast<DayOfWeek>().ToList();
			var startTime = dateTimePickerStartTime.Value.TimeOfDay;
			var endTime = dateTimePickerEndTime.Value.TimeOfDay;

			foreach (var day in selectedDays)
			{
				var constraint = new TeacherConstraintViewModel
				{
					Id = Guid.NewGuid(),
					TeacherId = selectedTeacher?.Id ?? Guid.Empty,
					Teacher = selectedTeacher!,
					DayOfWeek = day,
					StartTime = startTime,
					EndTime = endTime
				};

				var teacher = teachers.FirstOrDefault(t => t.Id == t.Id);
				teacher?.Constraints.Add(constraint);
			}


			logger.Info("Ограничения добавлены для выбранного преподавателя.");
		}

		private void PopulateCheckedListBoxWithDaysOfWeek(CheckedListBox checkedListBox)
		{
			foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
			{
				checkedListBox.Items.Add(day);
			}
		}

		private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDepartment = (Department?)cbDepartment.SelectedItem;
		}

		private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && e.KeyChar != '+')
			{
				e.Handled = true;
			}
		}

		public static string GetEnumDisplayName<T>(T enumValue) where T : Enum
		{
			var fieldInfo = typeof(T).GetField(enumValue.ToString());
			var displayAttribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
			return displayAttribute?.Name ?? enumValue.ToString();
		}
	}
}
