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
			btnGenerateReport = new Button();
			lblAverage = new Label();
			btnSelectPath = new Button();
			folderBrowserDialog1 = new FolderBrowserDialog();
			label2 = new Label();
			txtSelectedPath = new TextBox();
			label3 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Roboto", 18F);
			label1.Location = new Point(51, 46);
			label1.Name = "label1";
			label1.Size = new Size(217, 29);
			label1.TabIndex = 0;
			label1.Text = "Estado Académico";
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Font = new Font("Roboto", 14F);
			lblName.Location = new Point(51, 93);
			lblName.Name = "lblName";
			lblName.Size = new Size(149, 23);
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
			lblCountPassedSubjects.Location = new Point(51, 304);
			lblCountPassedSubjects.Name = "lblCountPassedSubjects";
			lblCountPassedSubjects.Size = new Size(38, 15);
			lblCountPassedSubjects.TabIndex = 2;
			lblCountPassedSubjects.Text = "label2";
			// 
			// lblCountFailedSubjects
			// 
			lblCountFailedSubjects.AutoSize = true;
			lblCountFailedSubjects.Location = new Point(51, 346);
			lblCountFailedSubjects.Name = "lblCountFailedSubjects";
			lblCountFailedSubjects.Size = new Size(38, 15);
			lblCountFailedSubjects.TabIndex = 2;
			lblCountFailedSubjects.Text = "label2";
			// 
			// btnGenerateReport
			// 
			btnGenerateReport.Location = new Point(51, 566);
			btnGenerateReport.Name = "btnGenerateReport";
			btnGenerateReport.Size = new Size(144, 38);
			btnGenerateReport.TabIndex = 3;
			btnGenerateReport.Text = "Generar Reporte";
			btnGenerateReport.UseVisualStyleBackColor = true;
			btnGenerateReport.Click += btnGenerateReport_Click;
			// 
			// lblAverage
			// 
			lblAverage.AutoSize = true;
			lblAverage.Location = new Point(51, 265);
			lblAverage.Name = "lblAverage";
			lblAverage.Size = new Size(38, 15);
			lblAverage.TabIndex = 2;
			lblAverage.Text = "label2";
			// 
			// btnSelectPath
			// 
			btnSelectPath.Location = new Point(549, 499);
			btnSelectPath.Name = "btnSelectPath";
			btnSelectPath.Size = new Size(30, 23);
			btnSelectPath.TabIndex = 4;
			btnSelectPath.Text = "...";
			btnSelectPath.UseVisualStyleBackColor = true;
			btnSelectPath.Click += btnSelectPath_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(51, 428);
			label2.Name = "label2";
			label2.Size = new Size(188, 29);
			label2.TabIndex = 5;
			label2.Text = "Generar Reporte";
			// 
			// txtSelectedPath
			// 
			txtSelectedPath.Enabled = false;
			txtSelectedPath.Location = new Point(54, 499);
			txtSelectedPath.Name = "txtSelectedPath";
			txtSelectedPath.Size = new Size(480, 23);
			txtSelectedPath.TabIndex = 6;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Roboto", 9F);
			label3.Location = new Point(54, 482);
			label3.Name = "label3";
			label3.Size = new Size(105, 14);
			label3.TabIndex = 7;
			label3.Text = "Directorio destino:";
			// 
			// FrmAcademicStatus
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 630);
			Controls.Add(label3);
			Controls.Add(txtSelectedPath);
			Controls.Add(label2);
			Controls.Add(btnSelectPath);
			Controls.Add(btnGenerateReport);
			Controls.Add(lblAverage);
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
		private Button btnGenerateReport;
		private Label lblAverage;
		private Button btnSelectPath;
		private FolderBrowserDialog folderBrowserDialog1;
		private Label label2;
		private TextBox txtSelectedPath;
		private Label label3;
	}
}