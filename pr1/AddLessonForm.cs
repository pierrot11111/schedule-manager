using System;
using System.Windows.Forms;

namespace pr1
{
    public partial class AddLessonForm : Form
    {
        public Lesson CreatedLesson { get; private set; }
        private ErrorProvider errorProvider = new ErrorProvider();

        public AddLessonForm()
        {
            InitializeComponent();
            cmbLessonType.Items.AddRange(Enum.GetNames(typeof(LessonType)));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            // Валідація (ПР №6)
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                errorProvider.SetError(txtSubjectName, "Назва обов'язкова!");
                return;
            }

            try
            {
                var teacher = new Teacher(txtTeacherName.Text, "");
                var subject = new Subject(txtSubjectName.Text, teacher);
                Enum.TryParse(cmbLessonType.Text, out LessonType type);

                // Створюємо об'єкт для передачі в головну форму
                CreatedLesson = new Lesson(dtpLessonTime.Value, subject, type, txtLink.Text);

                this.DialogResult = DialogResult.OK; // Сигнал успіху
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}