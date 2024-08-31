namespace UI.Desktop.Course
{
    partial class frmCourse
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
            tsbtnAdd = new ToolStripButton();
            tsbtnEdit = new ToolStripButton();
            tsbtnRemove = new ToolStripButton();
            label1 = new Label();
            lstvCourses = new ListView();
            Commission = new ColumnHeader();
            Subject = new ColumnHeader();
            CalendarYear = new ColumnHeader();
            Capacity = new ColumnHeader();
            lblOutput = new Label();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAdd, tsbtnEdit, tsbtnRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.Click += toolStrip1_Click;
            // 
            // tsbtnAdd
            // 
            tsbtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAdd.Image = Properties.Resources.Add;
            tsbtnAdd.ImageTransparentColor = Color.Magenta;
            tsbtnAdd.Name = "tsbtnAdd";
            tsbtnAdd.Size = new Size(24, 24);
            tsbtnAdd.Text = "Crear Especialidad";
            // 
            // tsbtnEdit
            // 
            tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEdit.Image = Properties.Resources.Edit;
            tsbtnEdit.ImageTransparentColor = Color.Magenta;
            tsbtnEdit.Name = "tsbtnEdit";
            tsbtnEdit.Size = new Size(24, 24);
            tsbtnEdit.Text = "Editar Especialidad";
            // 
            // tsbtnRemove
            // 
            tsbtnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnRemove.Image = Properties.Resources.Delete;
            tsbtnRemove.ImageTransparentColor = Color.Magenta;
            tsbtnRemove.Name = "tsbtnRemove";
            tsbtnRemove.Size = new Size(24, 24);
            tsbtnRemove.Text = "Eliminar Especialidad";
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
            lstvCourses.Columns.AddRange(new ColumnHeader[] { Commission, Subject, CalendarYear, Capacity });
            lstvCourses.FullRowSelect = true;
            lstvCourses.GridLines = true;
            lstvCourses.Location = new Point(42, 134);
            lstvCourses.Name = "lstvCourses";
            lstvCourses.Size = new Size(678, 173);
            lstvCourses.TabIndex = 6;
            lstvCourses.UseCompatibleStateImageBehavior = false;
            lstvCourses.View = View.Details;
            lstvCourses.ColumnClick += lstvAreas_ColumnClick;
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
            // Capacity
            // 
            Capacity.Tag = "Capacity";
            Capacity.Text = "Cupo";
            Capacity.Width = 100;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(96, 352);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(38, 15);
            lblOutput.TabIndex = 9;
            lblOutput.Text = "label2";
            // 
            // frmCourse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblOutput);
            Controls.Add(label1);
            Controls.Add(lstvCourses);
            Controls.Add(toolStrip1);
            Name = "frmCourse";
            Text = "frmCourse";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbtnAdd;
        private ToolStripButton tsbtnEdit;
        private ToolStripButton tsbtnRemove;
        private Label label1;
        private ListView lstvCourses;
        private ColumnHeader Commission;
        private ColumnHeader Subject;
        private ColumnHeader CalendarYear;
        private ColumnHeader Capacity;
        private Label lblOutput;
    }
}