namespace UI.Desktop.Course
{
    partial class FrmMyCourses
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
			lstvMyCourses = new ListView();
			Commission = new ColumnHeader();
			Subject = new ColumnHeader();
			CalendarYear = new ColumnHeader();
			Level = new ColumnHeader();
			btnCancelInscription = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(44, 62);
			label1.Name = "label1";
			label1.Size = new Size(104, 21);
			label1.TabIndex = 10;
			label1.Text = "Mis Cursados";
			// 
			// lstvMyCourses
			// 
			lstvMyCourses.Columns.AddRange(new ColumnHeader[] { Commission, Subject, CalendarYear, Level });
			lstvMyCourses.FullRowSelect = true;
			lstvMyCourses.GridLines = true;
			lstvMyCourses.Location = new Point(44, 118);
			lstvMyCourses.Name = "lstvMyCourses";
			lstvMyCourses.Size = new Size(678, 173);
			lstvMyCourses.TabIndex = 9;
			lstvMyCourses.UseCompatibleStateImageBehavior = false;
			lstvMyCourses.View = View.Details;
			// 
			// Commission
			// 
			Commission.Tag = "Commission";
			Commission.Text = "Comision";
			Commission.Width = 200;
			// 
			// Subject
			// 
			Subject.Tag = "Subject.Description";
			Subject.Text = "Materia";
			Subject.Width = 200;
			// 
			// CalendarYear
			// 
			CalendarYear.Tag = "CalendarYear";
			CalendarYear.Text = "Año Calendario";
			CalendarYear.Width = 100;
			// 
			// Level
			// 
			Level.Text = "Nivel";
			Level.Width = 100;
			// 
			// btnCancelInscription
			// 
			btnCancelInscription.BackColor = Color.FromArgb(220, 53, 69);
			btnCancelInscription.FlatStyle = FlatStyle.Flat;
			btnCancelInscription.Font = new Font("Segoe UI", 12F);
			btnCancelInscription.ForeColor = SystemColors.ButtonHighlight;
			btnCancelInscription.Location = new Point(556, 330);
			btnCancelInscription.Margin = new Padding(3, 2, 3, 2);
			btnCancelInscription.Name = "btnCancelInscription";
			btnCancelInscription.Size = new Size(166, 50);
			btnCancelInscription.TabIndex = 11;
			btnCancelInscription.Text = "Eliminar Inscripcion";
			btnCancelInscription.UseVisualStyleBackColor = false;
			btnCancelInscription.Click += btnCancelInscription_Click;
			// 
			// FrmMyCourses
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancelInscription);
			Controls.Add(label1);
			Controls.Add(lstvMyCourses);
			Name = "FrmMyCourses";
			Text = "Mis Cursados";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private ListView lstvMyCourses;
        private ColumnHeader Commission;
        private ColumnHeader Subject;
        private ColumnHeader CalendarYear;
        private ColumnHeader Level;
		private Button btnCancelInscription;
	}
}