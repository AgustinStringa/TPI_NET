namespace UI.Desktop.Subject
{
    partial class FrmSubject
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
            tsbtnDelete = new ToolStripButton();
            listView1 = new ListView();
            description = new ColumnHeader();
            curriculumDescription = new ColumnHeader();
            level = new ColumnHeader();
            weeklyHours = new ColumnHeader();
            totalHours = new ColumnHeader();
            txtSearchSubject = new TextBox();
            label2 = new Label();
            label4 = new Label();
            cbCurriculum = new ComboBox();
            btnResetFilters = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAdd, tsbtnEdit, tsbtnDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1213, 27);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            tsbtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAdd.Image = Properties.Resources.Add;
            tsbtnAdd.ImageTransparentColor = Color.Magenta;
            tsbtnAdd.Name = "tsbtnAdd";
            tsbtnAdd.Size = new Size(24, 24);
            tsbtnAdd.Text = "add";
            tsbtnAdd.Click += tsbtnAdd_Click;
            // 
            // tsbtnEdit
            // 
            tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEdit.Image = Properties.Resources.Edit;
            tsbtnEdit.ImageTransparentColor = Color.Magenta;
            tsbtnEdit.Name = "tsbtnEdit";
            tsbtnEdit.Size = new Size(24, 24);
            tsbtnEdit.Text = "edit";
            tsbtnEdit.Click += tsbtnEdit_Click;
            // 
            // tsbtnDelete
            // 
            tsbtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnDelete.Image = Properties.Resources.Delete;
            tsbtnDelete.ImageTransparentColor = Color.Magenta;
            tsbtnDelete.Name = "tsbtnDelete";
            tsbtnDelete.Size = new Size(24, 24);
            tsbtnDelete.Click += tsbtnDelete_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { description, curriculumDescription, level, weeklyHours, totalHours });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(27, 187);
            listView1.Name = "listView1";
            listView1.Size = new Size(950, 216);
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // description
            // 
            description.Text = "Nombre";
            description.Width = 300;
            // 
            // curriculumDescription
            // 
            curriculumDescription.Text = "Plan de Estudios";
            curriculumDescription.Width = 200;
            // 
            // level
            // 
            level.Text = "Nivel";
            level.Width = 100;
            // 
            // weeklyHours
            // 
            weeklyHours.Text = "Horas Semanales";
            weeklyHours.Width = 120;
            // 
            // totalHours
            // 
            totalHours.Text = "Horas Totales";
            totalHours.Width = 100;
            // 
            // txtSearchSubject
            // 
            txtSearchSubject.Location = new Point(27, 96);
            txtSearchSubject.Name = "txtSearchSubject";
            txtSearchSubject.Size = new Size(252, 23);
            txtSearchSubject.TabIndex = 16;
            txtSearchSubject.TextChanged += txtSearchSubject_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 69);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 17;
            label2.Text = "Buscar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 145);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 18;
            label4.Text = "Plan de estudios:";
            // 
            // cbCurriculum
            // 
            cbCurriculum.FormattingEnabled = true;
            cbCurriculum.Location = new Point(142, 145);
            cbCurriculum.Name = "cbCurriculum";
            cbCurriculum.Size = new Size(225, 23);
            cbCurriculum.TabIndex = 22;
            cbCurriculum.SelectedValueChanged += cbCurriculum_SelectedValueChanged;
            // 
            // btnResetFilters
            // 
            btnResetFilters.Location = new Point(497, 86);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(121, 41);
            btnResetFilters.TabIndex = 23;
            btnResetFilters.Text = "Restablecer Filtros";
            btnResetFilters.UseVisualStyleBackColor = true;
            btnResetFilters.Click += btnResetFilters_Click;
            // 
            // FrmSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 542);
            Controls.Add(btnResetFilters);
            Controls.Add(cbCurriculum);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(txtSearchSubject);
            Controls.Add(listView1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmSubject";
            Text = "frmMateria";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTotalHour;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbtnAdd;
        private ToolStripButton tsbtnEdit;
        private ToolStripButton tsbtnDelete;
        private ListView listView1;
        private ColumnHeader description;
        private ColumnHeader curriculumDescription;
        private ColumnHeader level;
        private ColumnHeader weeklyHours;
        private ColumnHeader totalHours;
        private TextBox txtSearchSubject;
        private Label label2;
        private Label label4;
        private ComboBox cbCurriculum;
        private Button btnResetFilters;
    }
}