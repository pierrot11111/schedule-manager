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
            SetupMiniGrid();
            UpdateMiniGrid();
        }

        private void SetupMiniGrid()
        {
            dgvAllLessons.AutoGenerateColumns = false;
            dgvAllLessons.Columns.Clear();
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 60, DefaultCellStyle = { Format = "HH:mm" } });
            dgvAllLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 150 });

            dgvAllLessons.CellFormatting += (s, e) => {
                if (dgvAllLessons.Columns[e.ColumnIndex].Name == "SubjCol" && dgvAllLessons.Rows[e.RowIndex].DataBoundItem is Lesson l)
                    e.Value = l.CurrentSubject?.Name; 
            };
        }

        private void UpdateMiniGrid() => dgvAllLessons.DataSource = _repo.GetAll().ToList();

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валідація (ПР №6)
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text)) return;

            // 2. Створення об'єктів
            var teacher = new Teacher(txtTeacherName.Text, "");
            var subject = new Subject(txtSubjectName.Text, teacher);
            Enum.TryParse(cmbLessonType.Text, out LessonType type);

            var newLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text);

            // 3. ЗБЕРЕЖЕННЯ В РЕПОЗИТОРІЙ (Важливо зробити це ТУТ)
            _repo.Add(newLesson);

            // 4. Оновлення списку прямо у вікні додавання
            UpdateMiniGrid();

            // 5. Очищення полів для наступної пари (замість закриття вікна)
            txtSubjectName.Clear();
            txtLink.Clear();

            // Якщо ти хочеш, щоб вікно все ж таки закрилося — залиш ці два рядки:
            // this.DialogResult = DialogResult.OK;
            // this.Close();
        }

        private void btnDeleteInForm_Click(object sender, EventArgs e)
        {
            if (dgvAllLessons.CurrentRow?.DataBoundItem is Lesson selected)
            {
                if (MessageBox.Show("Видалити?", "ПР №7", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _repo.Delete(selected);
                    UpdateMiniGrid();
                }
            }
        }
    }
}