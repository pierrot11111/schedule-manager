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
            btnOpenAddForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLessons).BeginInit();
            SuspendLayout();
            // 
            // dgvLessons
            // 
            dgvLessons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLessons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLessons.Location = new Point(12, 12);
            dgvLessons.Name = "dgvLessons";
            dgvLessons.Size = new Size(603, 150);
            dgvLessons.TabIndex = 0;
            dgvLessons.CellFormatting += dgvLessons_CellFormatting;
            // 
            // btnOpenAddForm
            // 
            btnOpenAddForm.Location = new Point(12, 168);
            btnOpenAddForm.Name = "btnOpenAddForm";
            btnOpenAddForm.Size = new Size(75, 23);
            btnOpenAddForm.TabIndex = 1;
            btnOpenAddForm.Text = "Додати заняття";
            btnOpenAddForm.UseVisualStyleBackColor = true;
            btnOpenAddForm.Click += btnOpenAddForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpenAddForm);
            Controls.Add(dgvLessons);
            Name = "Form1";
            Text = "KPI Schedule Manager - Group IC-51";
            ((System.ComponentModel.ISupportInitialize)dgvLessons).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLessons;
        private Button btnOpenAddForm;
    }
}
