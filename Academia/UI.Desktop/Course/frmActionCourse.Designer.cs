namespace UI.Desktop.Course
{
    partial class FrmActionCourse
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
			lblSubject = new Label();
			cmbSubjects = new ComboBox();
			panel1 = new Panel();
			lstSelectedTeachers = new ListView();
			columnHeader1 = new ColumnHeader();
			btnDeleteTeacher = new Button();
			btnAddTeacher = new Button();
			btnActionCourse = new Button();
			txtCalendarYear = new TextBox();
			txtCapacity = new TextBox();
			lblTeachers = new Label();
			lblCalendarYear = new Label();
			lblCommission = new Label();
			lblCapacity = new Label();
			lblCalendarYearError = new Label();
			lblCapacityError = new Label();
			lblArea = new Label();
			lblCurriculum = new Label();
			cmbComissions = new ComboBox();
			cmbCurriculums = new ComboBox();
			cmbAreas = new ComboBox();
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
			// lblSubject
			// 
			lblSubject.AutoSize = true;
			lblSubject.Font = new Font("Segoe UI", 12F);
			lblSubject.Location = new Point(36, 189);
			lblSubject.Name = "lblSubject";
			lblSubject.Size = new Size(66, 21);
			lblSubject.TabIndex = 9;
			lblSubject.Text = "Materia:";
			// 
			// cmbSubjects
			// 
			cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbSubjects.FormattingEnabled = true;
			cmbSubjects.Location = new Point(36, 213);
			cmbSubjects.Name = "cmbSubjects";
			cmbSubjects.Size = new Size(212, 23);
			cmbSubjects.TabIndex = 10;
			cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
			// 
			// panel1
			// 
			panel1.Controls.Add(lstSelectedTeachers);
			panel1.Controls.Add(btnDeleteTeacher);
			panel1.Controls.Add(btnAddTeacher);
			panel1.Controls.Add(btnActionCourse);
			panel1.Controls.Add(txtCalendarYear);
			panel1.Controls.Add(txtCapacity);
			panel1.Controls.Add(lblTeachers);
			panel1.Controls.Add(lblCalendarYear);
			panel1.Controls.Add(lblCommission);
			panel1.Controls.Add(lblCapacity);
			panel1.Controls.Add(lblCalendarYearError);
			panel1.Controls.Add(lblCapacityError);
			panel1.Controls.Add(lblArea);
			panel1.Controls.Add(lblCurriculum);
			panel1.Controls.Add(lblSubject);
			panel1.Controls.Add(cmbComissions);
			panel1.Controls.Add(cmbCurriculums);
			panel1.Controls.Add(cmbAreas);
			panel1.Controls.Add(cmbSubjects);
			panel1.Location = new Point(30, 87);
			panel1.Name = "panel1";
			panel1.Size = new Size(1085, 441);
			panel1.TabIndex = 11;
			// 
			// lstSelectedTeachers
			// 
			lstSelectedTeachers.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			lstSelectedTeachers.Location = new Point(820, 57);
			lstSelectedTeachers.Name = "lstSelectedTeachers";
			lstSelectedTeachers.Size = new Size(235, 153);
			lstSelectedTeachers.TabIndex = 15;
			lstSelectedTeachers.UseCompatibleStateImageBehavior = false;
			lstSelectedTeachers.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Docente";
			columnHeader1.Width = 200;
			// 
			// btnDeleteTeacher
			// 
			btnDeleteTeacher.Image = Properties.Resources.Delete;
			btnDeleteTeacher.Location = new Point(725, 118);
			btnDeleteTeacher.Name = "btnDeleteTeacher";
			btnDeleteTeacher.Size = new Size(75, 43);
			btnDeleteTeacher.TabIndex = 14;
			btnDeleteTeacher.UseVisualStyleBackColor = true;
			btnDeleteTeacher.Click += btnDeleteTeacher_Click;
			// 
			// btnAddTeacher
			// 
			btnAddTeacher.Image = Properties.Resources.Add;
			btnAddTeacher.Location = new Point(725, 57);
			btnAddTeacher.Name = "btnAddTeacher";
			btnAddTeacher.Size = new Size(75, 43);
			btnAddTeacher.TabIndex = 14;
			btnAddTeacher.UseVisualStyleBackColor = true;
			btnAddTeacher.Click += btnAddTeacher_Click;
			// 
			// btnActionCourse
			// 
			btnActionCourse.BackColor = SystemColors.ActiveCaption;
			btnActionCourse.Font = new Font("Segoe UI", 12F);
			btnActionCourse.Location = new Point(908, 365);
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
			txtCapacity.Text = "0";
			// 
			// lblTeachers
			// 
			lblTeachers.AutoSize = true;
			lblTeachers.Font = new Font("Segoe UI", 12F);
			lblTeachers.Location = new Point(725, 16);
			lblTeachers.Name = "lblTeachers";
			lblTeachers.Size = new Size(153, 21);
			lblTeachers.TabIndex = 9;
			lblTeachers.Text = "Docentes Asginados:";
			// 
			// lblCalendarYear
			// 
			lblCalendarYear.AutoSize = true;
			lblCalendarYear.Font = new Font("Segoe UI", 12F);
			lblCalendarYear.Location = new Point(387, 105);
			lblCalendarYear.Name = "lblCalendarYear";
			lblCalendarYear.Size = new Size(120, 21);
			lblCalendarYear.TabIndex = 9;
			lblCalendarYear.Text = "Año Calendario:";
			// 
			// lblCommission
			// 
			lblCommission.AutoSize = true;
			lblCommission.Font = new Font("Segoe UI", 12F);
			lblCommission.Location = new Point(36, 272);
			lblCommission.Name = "lblCommission";
			lblCommission.Size = new Size(79, 21);
			lblCommission.TabIndex = 9;
			lblCommission.Text = "Comision:";
			// 
			// lblCapacity
			// 
			lblCapacity.AutoSize = true;
			lblCapacity.Font = new Font("Segoe UI", 12F);
			lblCapacity.Location = new Point(387, 16);
			lblCapacity.Name = "lblCapacity";
			lblCapacity.Size = new Size(50, 21);
			lblCapacity.TabIndex = 9;
			lblCapacity.Text = "Cupo:";
			// 
			// lblCalendarYearError
			// 
			lblCalendarYearError.AutoSize = true;
			lblCalendarYearError.Font = new Font("Segoe UI", 12F);
			lblCalendarYearError.Location = new Point(387, 155);
			lblCalendarYearError.Name = "lblCalendarYearError";
			lblCalendarYearError.Size = new Size(172, 21);
			lblCalendarYearError.TabIndex = 9;
			lblCalendarYearError.Text = "error en año calendario";
			lblCalendarYearError.Visible = false;
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
			lblCapacityError.Visible = false;
			// 
			// lblArea
			// 
			lblArea.AutoSize = true;
			lblArea.Font = new Font("Segoe UI", 12F);
			lblArea.Location = new Point(36, 16);
			lblArea.Name = "lblArea";
			lblArea.Size = new Size(98, 21);
			lblArea.TabIndex = 9;
			lblArea.Text = "Especialidad:";
			// 
			// lblCurriculum
			// 
			lblCurriculum.AutoSize = true;
			lblCurriculum.Font = new Font("Segoe UI", 12F);
			lblCurriculum.Location = new Point(36, 105);
			lblCurriculum.Name = "lblCurriculum";
			lblCurriculum.Size = new Size(128, 21);
			lblCurriculum.TabIndex = 9;
			lblCurriculum.Text = "Plan De Estudios:";
			// 
			// cmbComissions
			// 
			cmbComissions.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbComissions.FormattingEnabled = true;
			cmbComissions.Location = new Point(36, 296);
			cmbComissions.Name = "cmbComissions";
			cmbComissions.Size = new Size(212, 23);
			cmbComissions.TabIndex = 10;
			// 
			// cmbCurriculums
			// 
			cmbCurriculums.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbCurriculums.FormattingEnabled = true;
			cmbCurriculums.Location = new Point(36, 129);
			cmbCurriculums.Name = "cmbCurriculums";
			cmbCurriculums.Size = new Size(212, 23);
			cmbCurriculums.TabIndex = 10;
			cmbCurriculums.SelectedIndexChanged += cmbCurriculums_SelectedIndexChanged;
			// 
			// cmbAreas
			// 
			cmbAreas.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbAreas.FormattingEnabled = true;
			cmbAreas.Location = new Point(36, 40);
			cmbAreas.Name = "cmbAreas";
			cmbAreas.Size = new Size(212, 23);
			cmbAreas.TabIndex = 10;
			cmbAreas.SelectedIndexChanged += cmbAreas_SelectedIndexChanged;
			// 
			// FrmActionCourse
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1153, 540);
			Controls.Add(panel1);
			Controls.Add(label1);
			Name = "FrmActionCourse";
			Text = "frmActionCourse";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label lblSubject;
        private ComboBox cmbSubjects;
        private Panel panel1;
        private TextBox txtCapacity;
        private Label lblCommission;
        private ComboBox cmbComissions;
        private TextBox txtCalendarYear;
        private Label lblCalendarYear;
        private Label lblCapacity;
        private Button btnActionCourse;
        private Label lblArea;
        private ComboBox cmbAreas;
        private Label lblCalendarYearError;
        private Label lblCapacityError;
        private Label lblCurriculum;
        private ComboBox cmbCurriculums;
		private Label lblTeachers;
		private Button btnDeleteTeacher;
		private Button btnAddTeacher;
		private ListView lstSelectedTeachers;
		private ColumnHeader columnHeader1;
	}
}