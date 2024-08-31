namespace UI.Desktop.Course
{
    partial class frmActionCourse
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
            label1 = new Label();
            label2 = new Label();
            cmbSubjects = new ComboBox();
            panel1 = new Panel();
            btnActionCourse = new Button();
            txtCalendarYear = new TextBox();
            txtCapacity = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblCalendarYearError = new Label();
            lblCapacityError = new Label();
            label6 = new Label();
            cmbComissions = new ComboBox();
            cmbAreas = new ComboBox();
            cmbCurriculums = new ComboBox();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(30, 38);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 9;
            label1.Text = "Editar Cursado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(36, 189);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 9;
            label2.Text = "Materia:";
            // 
            // cmbSubjects
            // 
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(36, 213);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(212, 23);
            cmbSubjects.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActionCourse);
            panel1.Controls.Add(txtCalendarYear);
            panel1.Controls.Add(txtCapacity);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblCalendarYearError);
            panel1.Controls.Add(lblCapacityError);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbComissions);
            panel1.Controls.Add(cmbCurriculums);
            panel1.Controls.Add(cmbAreas);
            panel1.Controls.Add(cmbSubjects);
            panel1.Location = new Point(30, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(632, 351);
            panel1.TabIndex = 11;
            // 
            // btnActionCourse
            // 
            btnActionCourse.BackColor = SystemColors.ActiveCaption;
            btnActionCourse.Font = new Font("Segoe UI", 12F);
            btnActionCourse.Location = new Point(437, 272);
            btnActionCourse.Name = "btnActionCourse";
            btnActionCourse.Size = new Size(147, 60);
            btnActionCourse.TabIndex = 12;
            btnActionCourse.Text = "Crear Cursado";
            btnActionCourse.UseVisualStyleBackColor = false;
            btnActionCourse.Click += btnActionCourse_Click;
            // 
            // txtCalendarYear
            // 
            txtCalendarYear.Location = new Point(387, 129);
            txtCalendarYear.Name = "txtCalendarYear";
            txtCalendarYear.Size = new Size(197, 23);
            txtCalendarYear.TabIndex = 11;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(387, 40);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(197, 23);
            txtCapacity.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(387, 105);
            label5.Name = "label5";
            label5.Size = new Size(120, 21);
            label5.TabIndex = 9;
            label5.Text = "Año Calendario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(36, 272);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 9;
            label3.Text = "Comision:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(387, 16);
            label4.Name = "label4";
            label4.Size = new Size(50, 21);
            label4.TabIndex = 9;
            label4.Text = "Cupo:";
            // 
            // lblCalendarYearError
            // 
            lblCalendarYearError.AutoSize = true;
            lblCalendarYearError.Font = new Font("Segoe UI", 12F);
            lblCalendarYearError.Location = new Point(387, 155);
            lblCalendarYearError.Name = "lblCalendarYearError";
            lblCalendarYearError.Size = new Size(98, 21);
            lblCalendarYearError.TabIndex = 9;
            lblCalendarYearError.Text = "Especialidad:";
            // 
            // lblCapacityError
            // 
            lblCapacityError.AutoSize = true;
            lblCapacityError.Font = new Font("Segoe UI", 12F);
            lblCapacityError.Location = new Point(387, 66);
            lblCapacityError.Name = "lblCapacityError";
            lblCapacityError.Size = new Size(167, 21);
            lblCapacityError.TabIndex = 9;
            lblCapacityError.Text = "Ingresa un cupo válido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(36, 16);
            label6.Name = "label6";
            label6.Size = new Size(98, 21);
            label6.TabIndex = 9;
            label6.Text = "Especialidad:";
            // 
            // cmbComissions
            // 
            cmbComissions.FormattingEnabled = true;
            cmbComissions.Location = new Point(36, 296);
            cmbComissions.Name = "cmbComissions";
            cmbComissions.Size = new Size(212, 23);
            cmbComissions.TabIndex = 10;
            // 
            // cmbAreas
            // 
            cmbAreas.FormattingEnabled = true;
            cmbAreas.Location = new Point(36, 40);
            cmbAreas.Name = "cmbAreas";
            cmbAreas.Size = new Size(212, 23);
            cmbAreas.TabIndex = 10;
            // 
            // cmbCurriculums
            // 
            cmbCurriculums.FormattingEnabled = true;
            cmbCurriculums.Location = new Point(36, 129);
            cmbCurriculums.Name = "cmbCurriculums";
            cmbCurriculums.Size = new Size(212, 23);
            cmbCurriculums.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(36, 105);
            label7.Name = "label7";
            label7.Size = new Size(128, 21);
            label7.TabIndex = 9;
            label7.Text = "Plan De Estudios:";
            // 
            // frmActionCourse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 450);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "frmActionCourse";
            Text = "frmActionCourse";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbSubjects;
        private Panel panel1;
        private TextBox txtCapacity;
        private Label label3;
        private ComboBox cmbComissions;
        private TextBox txtCalendarYear;
        private Label label5;
        private Label label4;
        private Button btnActionCourse;
        private Label label6;
        private ComboBox cmbAreas;
        private Label lblCalendarYearError;
        private Label lblCapacityError;
        private Label label7;
        private ComboBox cmbCurriculums;
    }
}