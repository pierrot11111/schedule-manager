using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace pr1
{
    public partial class Form1 : Form
    {
        // Створюємо репозиторій для роботи з даними (ПР №3)
        private readonly LessonRepository _repository = new LessonRepository();

        public Form1()
        {
            InitializeComponent();
            SetupGrid();

            // Заповнюємо випадаючий список
            cmbLessonType.Items.AddRange(Enum.GetNames(typeof(LessonType)));

            // ОНОВЛЮЄМО ТАБЛИЦЮ ВІДРАЗУ ПРИ ЗАПУСКУ
            UpdateGrid();
        }

        // Налаштування зовнішнього вигляду таблиці
        private void SetupGrid()
        {
            dgvLessons.AutoGenerateColumns = false;
            dgvLessons.Columns.Clear();

            // 1. Стовпець для Часу
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Time",
                HeaderText = "Час",
                Width = 100
            });

            // 2. Стовпець для Предмета (Назва береться через CellFormatting)
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubjectCol",
                HeaderText = "Назва предмета",
                Width = 150
            });

            // 3. Стовпець для Викладача (ПІБ береться через CellFormatting)
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TeacherCol",
                HeaderText = "Викладач",
                Width = 150
            });

            // 4. Тип пари
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Тип",
                Width = 80
            });

            // 5. Посилання (на всю ширину)
            dgvLessons.Columns.Add(new DataGridViewLinkColumn
            {
                DataPropertyName = "ZoomLink",
                HeaderText = "Посилання",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // Відображення тексту всередині вкладених об'єктів (ПР №4)
        private void dgvLessons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var lesson = dgvLessons.Rows[e.RowIndex].DataBoundItem as Lesson;
            if (lesson == null) return;

            // Виводимо назву предмета
            if (dgvLessons.Columns[e.ColumnIndex].Name == "SubjectCol")
            {
                e.Value = lesson.CurrentSubject?.Name;
                e.FormattingApplied = true;
            }

            // Виводимо ПІБ викладача
            if (dgvLessons.Columns[e.ColumnIndex].Name == "TeacherCol")
            {
                e.Value = lesson.CurrentSubject?.Lecturer?.FullName;
                e.FormattingApplied = true;
            }
        }

        // Кнопка ДОДАТИ (ПР №4: Операція Create)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) || string.IsNullOrWhiteSpace(txtTeacherName.Text))
            {
                MessageBox.Show("Будь ласка, заповніть назву предмета та викладача.");
                return;
            }

            // Створюємо об'єкти (Логіка ПР №2)
            var teacher = new Teacher(txtTeacherName.Text, string.Empty);
            var subject = new Subject(txtSubjectName.Text, teacher);

            Enum.TryParse(cmbLessonType.Text, out LessonType type);

            // Створюємо заняття
            var newLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text);

            // Зберігаємо в репозиторій (ПР №3)
            _repository.Add(newLesson);

            // Оновлюємо інтерфейс
            UpdateGrid();
            ClearFields();
        }

        // Кнопка ВИДАЛИТИ (ПР №4: Операція Delete)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLessons.CurrentRow?.DataBoundItem is Lesson selectedLesson)
            {
                _repository.Delete(selectedLesson);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Виберіть рядок для видалення.");
            }
        }

        private void UpdateGrid()
        {
            dgvLessons.DataSource = null;
            dgvLessons.DataSource = _repository.GetAll().ToList();
        }

        private void ClearFields()
        {
            txtSubjectName.Clear();
            txtTeacherName.Clear();
            txtLink.Clear();
            cmbLessonType.SelectedIndex = -1;
            dtpLessonTime.Value = DateTime.Now;
        }
    }
}