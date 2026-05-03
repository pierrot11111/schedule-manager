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
                g.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Time", HeaderText = "Час", Width = 65, DefaultCellStyle = { Format = "HH:mm" } });
                g.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubjCol", HeaderText = "Предмет", Width = 140 });
                g.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Тип", Width = 80 });
                g.Columns.Add(new DataGridViewLinkColumn { DataPropertyName = "ZoomLink", HeaderText = "Zoom", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                
                g.CellFormatting += dgv_CellFormatting;
            }
        }

        private void UpdateAllGrids()
        {
            var all = _repository.GetAll().ToList();
            // Фільтрація по днях тижня за допомогою LIN
            dgvMonday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Monday).ToList();
            dgvTuesday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Tuesday).ToList();
            dgvWednesday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Wednesday).ToList();
            dgvThursday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Thursday).ToList();
            dgvFriday.DataSource = all.Where(l => l.Time.DayOfWeek == DayOfWeek.Friday).ToList();
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