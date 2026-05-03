using System;
using System.Linq;
using System.Windows.Forms;

namespace pr1
{
    public partial class Form1 : Form
    {
        private readonly LessonRepository _repository = new LessonRepository();

        public Form1()
        {
            InitializeComponent();
            SetupGrid();
            UpdateGrid();
        }

        private void SetupGrid()
        {
            dgvLessons.AutoGenerateColumns = false;
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 110 });
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 150 });
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Тип" });
        }

        private void btnOpenAddForm_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddLessonForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    if (addForm.CreatedLesson != null)
                    {
                        _repository.Add(addForm.CreatedLesson);
                        UpdateGrid(); 
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLessons.CurrentRow?.DataBoundItem is Lesson selected)
            {
                if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _repository.Delete(selected);
                    UpdateGrid();
                }
            }
        }

        private void UpdateGrid()
        {
            dgvLessons.DataSource = null;
            dgvLessons.DataSource = _repository.GetAll(); // Вже відсортовано репозиторієм
        }

        private void dgvLessons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLessons.Rows[e.RowIndex].DataBoundItem is Lesson lesson)
            {
                if (dgvLessons.Columns[e.ColumnIndex].Name == "SubjCol")
                {
                    e.Value = lesson.CurrentSubject?.Name;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}