namespace UI.Desktop.Course
{
    partial class FrmCourse
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
			toolStrip1 = new ToolStrip();
			tsbtnAddCourse = new ToolStripButton();
			tsbtnEditCourse = new ToolStripButton();
			tsbtnRemoveCourse = new ToolStripButton();
			label1 = new Label();
			lstvCourses = new ListView();
			columnHeader1 = new ColumnHeader();
			Subject = new ColumnHeader();
			Commission = new ColumnHeader();
			CalendarYear = new ColumnHeader();
			Capacity = new ColumnHeader();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.ImageScalingSize = new Size(20, 20);
			toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAddCourse, tsbtnEditCourse, tsbtnRemoveCourse });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(895, 27);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// tsbtnAddCourse
			// 
			tsbtnAddCourse.DisplayStyle = ToolStripItemDisplayStyle.Image;
			tsbtnAddCourse.Image = Properties.Resources.Add;
			tsbtnAddCourse.ImageTransparentColor = Color.Magenta;
			tsbtnAddCourse.Name = "tsbtnAddCourse";
			tsbtnAddCourse.Size = new Size(24, 24);
			tsbtnAddCourse.Text = "toolStripButton1";
			tsbtnAddCourse.ToolTipText = "Crear Cursado";
			tsbtnAddCourse.Click += tsbtnAddCourse_Click;
			// 
			// tsbtnEditCourse
			// 
			tsbtnEditCourse.DisplayStyle = ToolStripItemDisplayStyle.Image;
			tsbtnEditCourse.Image = Properties.Resources.Edit;
			tsbtnEditCourse.ImageTransparentColor = Color.Magenta;
			tsbtnEditCourse.Name = "tsbtnEditCourse";
			tsbtnEditCourse.Size = new Size(24, 24);
			tsbtnEditCourse.Text = "toolStripButton1";
			tsbtnEditCourse.ToolTipText = "Editar Cursado";
			tsbtnEditCourse.Click += tsbtnEditCourse_Click;
			// 
			// tsbtnRemoveCourse
			// 
			tsbtnRemoveCourse.DisplayStyle = ToolStripItemDisplayStyle.Image;
			tsbtnRemoveCourse.Image = Properties.Resources.Delete;
			tsbtnRemoveCourse.ImageTransparentColor = Color.Magenta;
			tsbtnRemoveCourse.Name = "tsbtnRemoveCourse";
			tsbtnRemoveCourse.Size = new Size(24, 24);
			tsbtnRemoveCourse.Text = "toolStripButton1";
			tsbtnRemoveCourse.ToolTipText = "Eliminar Cursado";
			tsbtnRemoveCourse.Click += tsbtnRemoveCourse_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(42, 78);
			label1.Name = "label1";
			label1.Size = new Size(75, 21);
			label1.TabIndex = 8;
			label1.Text = "Cursados";
			// 
			// lstvCourses
			// 
			lstvCourses.Columns.AddRange(new ColumnHeader[] { columnHeader1, Subject, Commission, CalendarYear, Capacity });
			lstvCourses.FullRowSelect = true;
			lstvCourses.GridLines = true;
			lstvCourses.Location = new Point(42, 134);
			lstvCourses.Name = "lstvCourses";
			lstvCourses.Size = new Size(777, 173);
			lstvCourses.TabIndex = 6;
			lstvCourses.UseCompatibleStateImageBehavior = false;
			lstvCourses.View = View.Details;
			lstvCourses.ColumnClick += lstvAreas_ColumnClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Plan de Estudio";
			columnHeader1.Width = 150;
			// 
			// Subject
			// 
			Subject.Tag = "Subject.Description";
			Subject.Text = "Materia";
			Subject.Width = 200;
			// 
			// Commission
			// 
			Commission.Tag = "Commission";
			Commission.Text = "Comision";
			Commission.Width = 200;
			// 
			// CalendarYear
			// 
			CalendarYear.Tag = "CalendarYear";
			CalendarYear.Text = "Año Calendario";
			CalendarYear.Width = 100;
			// 
			// Capacity
			// 
			Capacity.Tag = "Capacity";
			Capacity.Text = "Cupo";
			Capacity.Width = 100;
			// 
			// FrmCourse
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(895, 450);
			Controls.Add(label1);
			Controls.Add(lstvCourses);
			Controls.Add(toolStrip1);
			Name = "FrmCourse";
			Text = "frmCourse";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
        private Label label1;
        private ListView lstvCourses;
        private ColumnHeader Commission;
        private ColumnHeader Subject;
        private ColumnHeader CalendarYear;
        private ColumnHeader Capacity;
		private ColumnHeader columnHeader1;
		private ToolStripButton tsbtnAddCourse;
		private ToolStripButton tsbtnEditCourse;
		private ToolStripButton tsbtnRemoveCourse;
	}
}