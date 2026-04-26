namespace pr1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvLessons = new DataGridView();
            txtSubjectName = new TextBox();
            txtTeacherName = new TextBox();
            dtpLessonTime = new DateTimePicker();
            cmbLessonType = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            txtLink = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLessons).BeginInit();
            SuspendLayout();
            // 
            // dgvLessons
            // 
            dgvLessons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLessons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLessons.Location = new Point(24, 196);
            dgvLessons.Name = "dgvLessons";
            dgvLessons.Size = new Size(603, 150);
            dgvLessons.TabIndex = 0;
            dgvLessons.CellFormatting += dgvLessons_CellFormatting;
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(24, 31);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(100, 23);
            txtSubjectName.TabIndex = 1;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(257, 31);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(100, 23);
            txtTeacherName.TabIndex = 2;
            // 
            // dtpLessonTime
            // 
            dtpLessonTime.Location = new Point(24, 113);
            dtpLessonTime.Name = "dtpLessonTime";
            dtpLessonTime.Size = new Size(200, 23);
            dtpLessonTime.TabIndex = 3;
            // 
            // cmbLessonType
            // 
            cmbLessonType.FormattingEnabled = true;
            cmbLessonType.Location = new Point(506, 31);
            cmbLessonType.Name = "cmbLessonType";
            cmbLessonType.Size = new Size(121, 23);
            cmbLessonType.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(412, 113);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(506, 113);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(257, 113);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(100, 23);
            txtLink.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 13);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 8;
            label1.Text = "Назва предмету";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(257, 13);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 9;
            label2.Text = "Викладач";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(257, 95);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 10;
            label3.Text = "Посилання";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(506, 13);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 11;
            label4.Text = "Тип пари";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLink);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(cmbLessonType);
            Controls.Add(dtpLessonTime);
            Controls.Add(txtTeacherName);
            Controls.Add(txtSubjectName);
            Controls.Add(dgvLessons);
            Name = "Form1";
            Text = "KPI Schedule Manager - Group IC-51";
            ((System.ComponentModel.ISupportInitialize)dgvLessons).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLessons;
        private TextBox txtSubjectName;
        private TextBox txtTeacherName;
        private DateTimePicker dtpLessonTime;
        private ComboBox cmbLessonType;
        private Button btnAdd;
        private Button btnDelete;
        private TextBox txtLink;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
