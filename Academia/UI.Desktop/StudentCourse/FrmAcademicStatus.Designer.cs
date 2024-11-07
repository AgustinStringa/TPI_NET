namespace UI.Desktop
{
    partial class FrmAcademicStatus
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
			lblName = new Label();
			lstAcademicStatus = new ListView();
			Materia = new ColumnHeader();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			CalendarYear = new ColumnHeader();
			SubjectLevel = new ColumnHeader();
			lblCountPassedSubjects = new Label();
			lblCountFailedSubjects = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(51, 62);
			label1.Name = "label1";
			label1.Size = new Size(105, 15);
			label1.TabIndex = 0;
			label1.Text = "Estado Académico";
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(51, 90);
			lblName.Name = "lblName";
			lblName.Size = new Size(97, 15);
			lblName.TabIndex = 0;
			lblName.Text = "Nombre Alumno";
			// 
			// lstAcademicStatus
			// 
			lstAcademicStatus.Columns.AddRange(new ColumnHeader[] { Materia, columnHeader1, columnHeader2, CalendarYear, SubjectLevel });
			lstAcademicStatus.Location = new Point(51, 131);
			lstAcademicStatus.Name = "lstAcademicStatus";
			lstAcademicStatus.Size = new Size(851, 97);
			lstAcademicStatus.TabIndex = 1;
			lstAcademicStatus.UseCompatibleStateImageBehavior = false;
			lstAcademicStatus.View = View.Details;
			// 
			// Materia
			// 
			Materia.Text = "Materia";
			Materia.Width = 350;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Estado";
			columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Nota";
			columnHeader2.Width = 100;
			// 
			// CalendarYear
			// 
			CalendarYear.Text = "Año Calendario";
			CalendarYear.Width = 120;
			// 
			// SubjectLevel
			// 
			SubjectLevel.Text = "Nivel";
			SubjectLevel.Width = 120;
			// 
			// lblCountPassedSubjects
			// 
			lblCountPassedSubjects.AutoSize = true;
			lblCountPassedSubjects.Location = new Point(51, 278);
			lblCountPassedSubjects.Name = "lblCountPassedSubjects";
			lblCountPassedSubjects.Size = new Size(38, 15);
			lblCountPassedSubjects.TabIndex = 2;
			lblCountPassedSubjects.Text = "label2";
			// 
			// lblCountFailedSubjects
			// 
			lblCountFailedSubjects.AutoSize = true;
			lblCountFailedSubjects.Location = new Point(51, 319);
			lblCountFailedSubjects.Name = "lblCountFailedSubjects";
			lblCountFailedSubjects.Size = new Size(38, 15);
			lblCountFailedSubjects.TabIndex = 2;
			lblCountFailedSubjects.Text = "label2";
			// 
			// FrmAcademicStatus
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 450);
			Controls.Add(lblCountFailedSubjects);
			Controls.Add(lblCountPassedSubjects);
			Controls.Add(lstAcademicStatus);
			Controls.Add(lblName);
			Controls.Add(label1);
			Name = "FrmAcademicStatus";
			Text = "Estado Academico";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label lblName;
        private ListView lstAcademicStatus;
        private ColumnHeader Materia;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
		private ColumnHeader CalendarYear;
		private ColumnHeader SubjectLevel;
		private Label lblCountPassedSubjects;
		private Label lblCountFailedSubjects;
	}
}