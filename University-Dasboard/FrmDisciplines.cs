using Database;
using System.ComponentModel;
using System.Data;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmDisciplines : Form
    {
        public FrmDisciplines()
        {
            InitializeComponent();
            LoadData();
        }

        private BindingList<Discipline> disciplines = [];
        private BindingList<Discipline> updatedDisciplinesList = [];
        private BindingList<Discipline> removedDisciplinesList = [];

        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            var disciplineList = ctx.Discipline.ToList();
            disciplines = new BindingList<Discipline>(disciplineList);
            dgvDisciplines.DataSource = disciplines;
            dgvDisciplines.Columns["Id"].Visible = false;
        }

        private void ClearTempLists()
        {
            updatedDisciplinesList.Clear();
            removedDisciplinesList.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newSubjectName = tbNewDisciplineName.Text;
            if (string.IsNullOrEmpty(newSubjectName))
            {
                MessageBox.Show("Введите название новой дисциплины");
                return;
            }

            Discipline discipline = new Discipline { Id = Guid.NewGuid(), Name = newSubjectName };
            disciplines.Add(discipline);
            updatedDisciplinesList.Add(discipline);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = true;
            try
            {
                using var ctx = new DatabaseContext();
                var existingSubjects = ctx.Discipline
                    .Where(d => updatedDisciplinesList.Select(u => u.Id).Contains(d.Id))
                    .ToDictionary(d => d.Id);

                foreach (Discipline subject in updatedDisciplinesList)
                {
                    if (existingSubjects.TryGetValue(subject.Id, out var existingSubject))
                    {
                        existingSubject.Name = subject.Name;
                    }
                    else
                    {
                        ctx.Discipline.Add(subject);
                    }
                }
                if (removedDisciplinesList.Count > 0)
                {
                    var subjectsToRemove = ctx.Discipline
                        .Where(d => removedDisciplinesList.Select(rd => rd.Id).Contains(d.Id))
                        .ToList();
                    ctx.Discipline.RemoveRange(subjectsToRemove);
                }
                ctx.SaveChanges();
                ClearTempLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex}");
            }
            lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
            lbDbSaveResult.Text = "Данные успешно сохранены.";
            await Task.Delay(3000);
            lbDbSaveResult.Visible = false;
        }
        private Discipline GetSubject(Guid id)
        {
            Discipline updatedSubject = disciplines.First(d => d.Id == id);
            return updatedSubject;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDisciplines.CurrentRow == null)
            {
                MessageBox.Show("Выделите строку для удаления");
                return;
            }
            var id = (Guid)dgvDisciplines.CurrentRow.Cells["Id"].Value;
            Discipline updatedSubject = GetSubject(id);
            disciplines.Remove(updatedSubject);
            updatedDisciplinesList.Remove(updatedSubject);
            removedDisciplinesList.Add(updatedSubject);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTempLists();
            LoadData();
        }

        private void dgvSubjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dgvDisciplines.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            Discipline updatedSubject = GetSubject(id);
            updatedDisciplinesList.Add(updatedSubject);
        }

        private void dgvSubjects_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender;
            var rowId = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, 
                grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowId, grid.Font, 
                SystemBrushes.ControlText, headerBounds, 
                centerFormat);
        }
    }
}
