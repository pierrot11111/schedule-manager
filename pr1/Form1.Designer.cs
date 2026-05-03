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
            dgvMonday = new DataGridView();
            btnOpenAddForm = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvTuesday = new DataGridView();
            label3 = new Label();
            dgvWednesday = new DataGridView();
            label4 = new Label();
            dgvThursday = new DataGridView();
            label5 = new Label();
            dgvFriday = new DataGridView();
            rbWeek1 = new RadioButton();
            rbWeek2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvMonday).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTuesday).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvWednesday).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvThursday).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFriday).BeginInit();
            SuspendLayout();
            // 
            // dgvMonday
            // 
            dgvMonday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonday.Location = new Point(12, 27);
            dgvMonday.Name = "dgvMonday";
            dgvMonday.Size = new Size(603, 150);
            dgvMonday.TabIndex = 0;
            dgvMonday.CellFormatting += dgv_CellFormatting;
            // 
            // btnOpenAddForm
            // 
            btnOpenAddForm.Location = new Point(654, 117);
            btnOpenAddForm.Name = "btnOpenAddForm";
            btnOpenAddForm.Size = new Size(75, 23);
            btnOpenAddForm.TabIndex = 1;
            btnOpenAddForm.Text = "Додати заняття";
            btnOpenAddForm.UseVisualStyleBackColor = true;
            btnOpenAddForm.Click += btnOpenAddForm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 2;
            label1.Text = "Понеділок";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 182);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Вівторок";
            // 
            // dgvTuesday
            // 
            dgvTuesday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTuesday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTuesday.Location = new Point(12, 200);
            dgvTuesday.Name = "dgvTuesday";
            dgvTuesday.Size = new Size(603, 150);
            dgvTuesday.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 355);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 6;
            label3.Text = "Середа";
            // 
            // dgvWednesday
            // 
            dgvWednesday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWednesday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWednesday.Location = new Point(12, 373);
            dgvWednesday.Name = "dgvWednesday";
            dgvWednesday.Size = new Size(603, 150);
            dgvWednesday.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 531);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 8;
            label4.Text = "Четверг";
            // 
            // dgvThursday
            // 
            dgvThursday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThursday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThursday.Location = new Point(12, 549);
            dgvThursday.Name = "dgvThursday";
            dgvThursday.Size = new Size(603, 150);
            dgvThursday.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 707);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 10;
            label5.Text = "П'ятниця";
            // 
            // dgvFriday
            // 
            dgvFriday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFriday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFriday.Location = new Point(12, 725);
            dgvFriday.Name = "dgvFriday";
            dgvFriday.Size = new Size(603, 150);
            dgvFriday.TabIndex = 9;
            // 
            // rbWeek1
            // 
            rbWeek1.AutoSize = true;
            rbWeek1.Location = new Point(654, 40);
            rbWeek1.Name = "rbWeek1";
            rbWeek1.Size = new Size(121, 19);
            rbWeek1.TabIndex = 11;
            rbWeek1.TabStop = true;
            rbWeek1.Text = "Перший тиждень";
            rbWeek1.UseVisualStyleBackColor = true;
            rbWeek1.CheckedChanged += rbWeek_CheckedChanged;
            // 
            // rbWeek2
            // 
            rbWeek2.AutoSize = true;
            rbWeek2.Location = new Point(654, 81);
            rbWeek2.Name = "rbWeek2";
            rbWeek2.Size = new Size(114, 19);
            rbWeek2.TabIndex = 12;
            rbWeek2.TabStop = true;
            rbWeek2.Text = "Другий тиждень";
            rbWeek2.UseVisualStyleBackColor = true;
            rbWeek2.CheckedChanged += rbWeek_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 887);
            Controls.Add(rbWeek2);
            Controls.Add(rbWeek1);
            Controls.Add(label5);
            Controls.Add(dgvFriday);
            Controls.Add(label4);
            Controls.Add(dgvThursday);
            Controls.Add(label3);
            Controls.Add(dgvWednesday);
            Controls.Add(label2);
            Controls.Add(dgvTuesday);
            Controls.Add(label1);
            Controls.Add(btnOpenAddForm);
            Controls.Add(dgvMonday);
            Name = "Form1";
            Text = "KPI Schedule Manager - Group IC-51";
            ((System.ComponentModel.ISupportInitialize)dgvMonday).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTuesday).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvWednesday).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvThursday).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFriday).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMonday;
        private Button btnOpenAddForm;
        private Label label1;
        private Label label2;
        private DataGridView dgvTuesday;
        private Label label3;
        private DataGridView dgvWednesday;
        private Label label4;
        private DataGridView dgvThursday;
        private Label label5;
        private DataGridView dgvFriday;
        private RadioButton rbWeek1;
        private RadioButton rbWeek2;
    }
}
