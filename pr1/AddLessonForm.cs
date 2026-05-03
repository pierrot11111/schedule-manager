using System;
using System.Linq;
using System.Windows.Forms;

namespace pr1
{
    public partial class AddLessonForm : Form
    {
        private readonly LessonRepository _repo;
        private ErrorProvider errorProvider = new ErrorProvider();

        public AddLessonForm(LessonRepository repository)
        {
            InitializeComponent();
            _repo = repository;

            cmbLessonType.Items.Clear();
            cmbLessonType.Items.AddRange(new object[] { "Лекція", "Практика", "Лабораторна" });
            cmbLessonType.SelectedIndex = 0;

            cmbWeek.Items.Clear();
            cmbWeek.Items.AddRange(new string[] { "Кожен тиждень", "1 тиждень", "2 тиждень" });
            cmbWeek.SelectedIndex = 0;

            SetupMiniGrid();
            UpdateMiniGrid();
        }

        private void dtpLessonTime_ValueChanged(object sender, EventArgs e)
        {
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int weekOfYear = cal.GetWeekOfYear(dtpLessonTime.Value, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            cmbWeek.SelectedIndex = (weekOfYear % 2 != 0) ? 1 : 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text)) { errorProvider.SetError(txtSubjectName, "Порожньо!"); hasError = true; }
            if (string.IsNullOrWhiteSpace(txtTeacherName.Text)) { errorProvider.SetError(txtTeacherName, "Порожньо!"); hasError = true; }
            if (hasError) return;

            var teacher = new Teacher(txtTeacherName.Text, "");
            var subject = new Subject(txtSubjectName.Text, teacher);

            LessonType type = cmbLessonType.SelectedIndex switch
            {
                1 => LessonType.Практика,
                2 => LessonType.Лабораторна,
                _ => LessonType.Лекція
            };

            int weekNum = cmbWeek.SelectedIndex;

            var newLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text, weekNum);
            _repo.Add(newLesson);
            UpdateMiniGrid();
            txtSubjectName.Clear();
        }

        private void SetupMiniGrid()
        {
            dgvAllLessons.AutoGenerateColumns = false;
            dgvAllLessons.Columns.Clear();
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 110 });
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 120 });
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WeekNumber", HeaderText = "Т", Width = 30 });

            dgvAllLessons.CellFormatting += (s, e) => {
                if (dgvAllLessons.Columns[e.ColumnIndex].Name == "SubjCol" && dgvAllLessons.Rows[e.RowIndex].DataBoundItem is Lesson l)
                    e.Value = l.CurrentSubject?.Name;
            };
        }

        private void UpdateMiniGrid() => dgvAllLessons.DataSource = _repo.GetAll().ToList();

        private void btnDeleteInForm_Click(object sender, EventArgs e)
        {
            if (dgvAllLessons.CurrentRow?.DataBoundItem is Lesson selected)
            {
                if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _repo.Delete(selected);
                    UpdateMiniGrid();
                }
            }
        }
    }
}