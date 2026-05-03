using System;
using System.Collections.Generic;
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
            SetupAllGrids();
            UpdateAllGrids();
        }

        private void SetupAllGrids()
        {
            DataGridView[] grids = { dgvMonday, dgvTuesday, dgvWednesday, dgvThursday, dgvFriday };
            foreach (var g in grids)
            {
                g.AutoGenerateColumns = false;
                g.Columns.Clear();
                g.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 60, DefaultCellStyle = { Format = "HH:mm" } });
                g.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 140 });
                g.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Тип", Width = 70 });
                g.Columns.Add(new DataGridViewLinkColumn { DataPropertyName = "ZoomLink", HeaderText = "Zoom", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

                g.CellFormatting += dgv_CellFormatting;
            }
        }

        private void UpdateAllGrids()
        {
            // rbWeek1 — це RadioButton для вибору першого тижня
            int selectedWeek = rbWeek1.Checked ? 1 : 2;
            var all = _repository.GetAll().ToList();

            // Фільтруємо за днем ТА за тижнем (або якщо пара щотижня)
            dgvMonday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Monday && (l.WeekNumber == selectedWeek || l.WeekNumber == 0)).ToList();
            dgvTuesday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Tuesday && (l.WeekNumber == selectedWeek || l.WeekNumber == 0)).ToList();
            dgvWednesday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Wednesday && (l.WeekNumber == selectedWeek || l.WeekNumber == 0)).ToList();
            dgvThursday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Thursday && (l.WeekNumber == selectedWeek || l.WeekNumber == 0)).ToList();
            dgvFriday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Friday && (l.WeekNumber == selectedWeek || l.WeekNumber == 0)).ToList();
        }

        // Прив'яжи цей метод до події CheckedChanged обох RadioButton на головній формі
        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            // Перевіряємо, чи RadioButton став активним (Checked)
            if (((RadioButton)sender).Checked)
            {
                UpdateAllGrids(); // Оновлюємо 5 таблиць згідно з вибраним тижнем
            }
        }
        private void btnOpenAddForm_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddLessonForm(_repository))
            {
                addForm.ShowDialog();
                UpdateAllGrids();
            }
        }

        private void dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid?.Rows[e.RowIndex].DataBoundItem is Lesson lesson)
            {
                if (grid.Columns[e.ColumnIndex].Name == "SubjCol")
                {
                    e.Value = lesson.CurrentSubject?.Name;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}