namespace pr1
{
    partial class AddLessonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSubjectName = new TextBox();
            txtTeacherName = new TextBox();
            cmbLessonType = new ComboBox();
            dtpLessonTime = new DateTimePicker();
            txtLink = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvAllLessons = new DataGridView();
            btnDeleteInForm = new Button();
            label6 = new Label();
            cmbWeek = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAllLessons).BeginInit();
            SuspendLayout();
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(12, 30);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(200, 23);
            txtSubjectName.TabIndex = 0;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(12, 78);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(200, 23);
            txtTeacherName.TabIndex = 1;
            // 
            // cmbLessonType
            // 
            cmbLessonType.FormattingEnabled = true;
            cmbLessonType.Location = new Point(12, 212);
            cmbLessonType.Name = "cmbLessonType";
            cmbLessonType.Size = new Size(200, 23);
            cmbLessonType.TabIndex = 2;
            // 
            // dtpLessonTime
            // 
            dtpLessonTime.Location = new Point(12, 123);
            dtpLessonTime.Name = "dtpLessonTime";
            dtpLessonTime.Size = new Size(200, 23);
            dtpLessonTime.TabIndex = 3;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(12, 256);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(200, 23);
            txtLink.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(12, 285);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(137, 285);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "Скасувати";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 7;
            label1.Text = "Назва предмета:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 8;
            label2.Text = "ПІБ викладача:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 194);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 9;
            label3.Text = "Тип заняття:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 105);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 10;
            label4.Text = "Дата та час:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 238);
            label5.Name = "label5";
            label5.Size = new Size(154, 15);
            label5.TabIndex = 11;
            label5.Text = "Посилання (Zoom/Teams):";
            // 
            // dgvAllLessons
            // 
            dgvAllLessons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllLessons.Location = new Point(317, 30);
            dgvAllLessons.Name = "dgvAllLessons";
            dgvAllLessons.Size = new Size(385, 249);
            dgvAllLessons.TabIndex = 12;
            // 
            // btnDeleteInForm
            // 
            btnDeleteInForm.Location = new Point(317, 285);
            btnDeleteInForm.Name = "btnDeleteInForm";
            btnDeleteInForm.Size = new Size(75, 23);
            btnDeleteInForm.TabIndex = 13;
            btnDeleteInForm.Text = "Видалити";
            btnDeleteInForm.UseVisualStyleBackColor = true;
            btnDeleteInForm.Click += btnDeleteInForm_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(317, 12);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 14;
            label6.Text = "Всі пари";
            // 
            // cmbWeek
            // 
            cmbWeek.FormattingEnabled = true;
            cmbWeek.Location = new Point(12, 167);
            cmbWeek.Name = "cmbWeek";
            cmbWeek.Size = new Size(200, 23);
            cmbWeek.TabIndex = 15;
            cmbWeek.ValueMemberChanged += dtpLessonTime_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 149);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 16;
            label7.Text = "Тиждень:";
            label7.Click += label7_Click;
            // 
            // AddLessonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(cmbWeek);
            Controls.Add(label6);
            Controls.Add(btnDeleteInForm);
            Controls.Add(dgvAllLessons);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtLink);
            Controls.Add(dtpLessonTime);
            Controls.Add(cmbLessonType);
            Controls.Add(txtTeacherName);
            Controls.Add(txtSubjectName);
            Name = "AddLessonForm";
            Text = "Додати нове заняття";
            ((System.ComponentModel.ISupportInitialize)dgvAllLessons).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSubjectName;
        private TextBox txtTeacherName;
        private ComboBox cmbLessonType;
        private DateTimePicker dtpLessonTime;
        private TextBox txtLink;
        private Button btnSave;
        private Button btnClose;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvAllLessons;
        private Button btnDeleteInForm;
        private Label label6;
        private ComboBox cmbWeek;
        private Label label7;
    }
}