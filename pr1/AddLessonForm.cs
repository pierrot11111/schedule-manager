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

            cmbLessonType.Items.AddRange(Enum.GetNames(typeof(LessonType)));

            // Налаштовуємо ComboBox для тижнів
            cmbWeek.Items.AddRange(new string[] { "Кожен тиждень", "1 тиждень", "2 тиждень" });
            cmbWeek.SelectedIndex = 0;

            SetupMiniGrid();
            UpdateMiniGrid();
        }

        // Авто-визначення тижня при зміні дати
        private void dtpLessonTime_ValueChanged(object sender, EventArgs e)
        {
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;

            // Отримуємо номер тижня року
            int weekOfYear = cal.GetWeekOfYear(
                dtpLessonTime.Value,
                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);

            // Логіка: непарний тиждень року = 1 тиждень, парний = 2 тиждень
            if (weekOfYear % 2 != 0)
            {
                cmbWeek.SelectedIndex = 1; // "1 тиждень" у твоєму списку
            }
            else
            {
                cmbWeek.SelectedIndex = 2; // "2 тиждень" у твоєму списку
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                errorProvider.SetError(txtSubjectName, "Назва обов'язкова!");
                hasError = true;
            }

            if (hasError) return;

            var teacher = new Teacher(txtTeacherName.Text, "");
            var subject = new Subject(txtSubjectName.Text, teacher);
            Enum.TryParse(cmbLessonType.Text, out LessonType type);

            int weekNum = cmbWeek.SelectedIndex; // 0, 1 або 2

            var newLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text, weekNum);
            _repo.Add(newLesson);

            UpdateMiniGrid();
            txtSubjectName.Clear();
        }

        private void SetupMiniGrid()
        {
            dgvAllLessons.AutoGenerateColumns = false;
            dgvAllLessons.Columns.Clear();
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Дата/Час", Width = 110 });
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 120 });
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WeekNumber", HeaderText = "Т", Width = 30 });

            dgvAllLessons.CellFormatting += (s, e) =>
            {
                if (dgvAllLessons.Columns[e.ColumnIndex].Name == "SubjCol" && dgvAllLessons.Rows[e.RowIndex].DataBoundItem is Lesson l)
                    e.Value = l.CurrentSubject?.Name;
            };
        }

        private void UpdateMiniGrid() => dgvAllLessons.DataSource = _repo.GetAll().ToList();

        private void btnDeleteInForm_Click(object sender, EventArgs e)
        {
            if (dgvAllLessons.CurrentRow?.DataBoundItem is Lesson selected)
            {
                _repo.Delete(selected);
                UpdateMiniGrid();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}