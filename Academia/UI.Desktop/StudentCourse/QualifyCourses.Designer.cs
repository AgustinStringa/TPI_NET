namespace UI.Desktop
{
	partial class QualifyCourses
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
			lstUsers = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			lstUserCourses = new ListView();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();
			label1 = new Label();
			label2 = new Label();
			btnLoadGrade = new Button();
			txtSearchStudent = new TextBox();
			panelNoCourses = new Panel();
			lblNoCourses = new Label();
			panelNoCourses.SuspendLayout();
			SuspendLayout();
			// 
			// lstUsers
			// 
			lstUsers.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
			lstUsers.FullRowSelect = true;
			lstUsers.Location = new Point(32, 155);
			lstUsers.Name = "lstUsers";
			lstUsers.Size = new Size(417, 220);
			lstUsers.TabIndex = 0;
			lstUsers.UseCompatibleStateImageBehavior = false;
			lstUsers.View = View.Details;
			lstUsers.SelectedIndexChanged += lstUsers_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Especialidad";
			columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Nombre Alumno";
			columnHeader2.Width = 200;
			// 
			// lstUserCourses
			// 
			lstUserCourses.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5 });
			lstUserCourses.FullRowSelect = true;
			lstUserCourses.Location = new Point(498, 155);
			lstUserCourses.Name = "lstUserCourses";
			lstUserCourses.Size = new Size(486, 220);
			lstUserCourses.TabIndex = 1;
			lstUserCourses.UseCompatibleStateImageBehavior = false;
			lstUserCourses.View = View.Details;
			lstUserCourses.SelectedIndexChanged += lstUserCourses_SelectedIndexChanged;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Materia";
			columnHeader3.Width = 200;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Comision";
			columnHeader4.Width = 120;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "Nota";
			columnHeader5.Width = 120;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(32, 68);
			label1.Name = "label1";
			label1.Size = new Size(148, 21);
			label1.TabIndex = 2;
			label1.Text = "Seleccionar Alumno";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(498, 68);
			label2.Name = "label2";
			label2.Size = new Size(151, 21);
			label2.TabIndex = 2;
			label2.Text = "Seleccionar Cursado";
			// 
			// btnLoadGrade
			// 
			btnLoadGrade.BackColor = SystemColors.ActiveCaption;
			btnLoadGrade.Enabled = false;
			btnLoadGrade.Location = new Point(418, 412);
			btnLoadGrade.Name = "btnLoadGrade";
			btnLoadGrade.Size = new Size(133, 54);
			btnLoadGrade.TabIndex = 3;
			btnLoadGrade.Text = "Ingresar Nota";
			btnLoadGrade.UseVisualStyleBackColor = false;
			btnLoadGrade.Click += btnLoadGrade_Click;
			// 
			// txtSearchStudent
			// 
			txtSearchStudent.Location = new Point(32, 114);
			txtSearchStudent.Name = "txtSearchStudent";
			txtSearchStudent.PlaceholderText = " Buscar";
			txtSearchStudent.Size = new Size(279, 23);
			txtSearchStudent.TabIndex = 4;
			txtSearchStudent.TextChanged += txtSearchStudent_TextChanged;
			// 
			// panelNoCourses
			// 
			panelNoCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelNoCourses.BackColor = SystemColors.ButtonHighlight;
			panelNoCourses.Controls.Add(lblNoCourses);
			panelNoCourses.Location = new Point(498, 155);
			panelNoCourses.Name = "panelNoCourses";
			panelNoCourses.Size = new Size(486, 220);
			panelNoCourses.TabIndex = 5;
			panelNoCourses.Visible = false;
			// 
			// lblNoCourses
			// 
			lblNoCourses.Dock = DockStyle.Fill;
			lblNoCourses.Font = new Font("Segoe UI", 16F);
			lblNoCourses.Location = new Point(0, 0);
			lblNoCourses.Name = "lblNoCourses";
			lblNoCourses.Size = new Size(486, 220);
			lblNoCourses.TabIndex = 0;
			lblNoCourses.Text = "El alumno \"\" \r\nno cuenta con cursados los cuales calificar";
			lblNoCourses.TextAlign = ContentAlignment.MiddleCenter;
			lblNoCourses.Visible = false;
			// 
			// QualifyCourses
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1008, 481);
			Controls.Add(panelNoCourses);
			Controls.Add(label1);
			Controls.Add(txtSearchStudent);
			Controls.Add(btnLoadGrade);
			Controls.Add(label2);
			Controls.Add(lstUserCourses);
			Controls.Add(lstUsers);
			Name = "QualifyCourses";
			Text = "Cargar Notas";
			panelNoCourses.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListView lstUsers;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ListView lstUserCourses;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		private Label label1;
		private Label label2;
		private Button btnLoadGrade;
		private TextBox txtSearchStudent;
		private Panel panelNoCourses;
		private Label lblNoCourses;
	}
}