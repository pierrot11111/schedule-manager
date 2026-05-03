using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace pr1
{
    public partial class Form1 : Form
    {
        private readonly LessonRepository _repository = new LessonRepository();
        private ErrorProvider errorProvider = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            SetupGrid();

            // Заповнення списку типів занять
            cmbLessonType.Items.AddRange(Enum.GetNames(typeof(LessonType)));

            // Завантаження даних у таблицю при старті
            UpdateGrid();
        }

        private void SetupGrid()
        {
            dgvLessons.AutoGenerateColumns = false;
            dgvLessons.Columns.Clear();

            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 110 });
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjectCol", HeaderText = "Назва предмета", Width = 150 });
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { Name = "TeacherCol", HeaderText = "Викладач", Width = 150 });
            dgvLessons.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Тип", Width = 80 });
            dgvLessons.Columns.Add(new DataGridViewLinkColumn { DataPropertyName = "ZoomLink", HeaderText = "Посилання", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        // Кнопка ДОДАТИ з валідацією (ПР №6)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Скидаємо старі помилки

            // 1. Валідація: Назва предмета
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                errorProvider.SetError(txtSubjectName, "Назва предмета не може бути порожньою!");
                return;
            }

            // 2. Валідація: Викладач
            if (string.IsNullOrWhiteSpace(txtTeacherName.Text))
            {
                errorProvider.SetError(txtTeacherName, "Вкажіть ПІБ викладача!");
                return;
            }

            // 3. Валідація: Посилання (Regex)
            if (!string.IsNullOrEmpty(txtLink.Text) && !Regex.IsMatch(txtLink.Text, @"^https?://"))
            {
                errorProvider.SetError(txtLink, "Посилання має починатися з http:// або https://");
                return;
            }

            // 4. Валідація: Вибір типу пари
            if (cmbLessonType.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, оберіть тип пари зі списку.", "Валідація", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var teacher = new Teacher(txtTeacherName.Text, string.Empty);
                var subject = new Subject(txtSubjectName.Text, teacher);
                Enum.TryParse(cmbLessonType.Text, out LessonType type);

                var newLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text);

                _repository.Add(newLesson);
                UpdateGrid();
                ClearFields();

                MessageBox.Show("Заняття успішно додано до розкладу!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при додаванні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка ВИДАЛИТИ з обробкою виключень (ПР №6)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLessons.CurrentRow?.DataBoundItem is Lesson selectedLesson)
                {
                    var result = MessageBox.Show("Видалити вибране заняття?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _repository.Delete(selectedLesson);
                        UpdateGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Спочатку виберіть рядок у таблиці.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}");
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

        private void dgvLessons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLessons.Rows[e.RowIndex].DataBoundItem is Lesson lesson)
            {
                if (dgvLessons.Columns[e.ColumnIndex].Name == "SubjectCol")
                {
                    e.Value = lesson.CurrentSubject?.Name;
                    e.FormattingApplied = true;
                }
                if (dgvLessons.Columns[e.ColumnIndex].Name == "TeacherCol")
                {
                    e.Value = lesson.CurrentSubject?.Lecturer?.FullName;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}