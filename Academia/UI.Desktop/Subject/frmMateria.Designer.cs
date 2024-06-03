namespace UI.Desktop
{
    partial class frmMateria
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
            txtSubjectName = new TextBox();
            labelMateria = new Label();
            txtWeekHour = new TextBox();
            label1 = new Label();
            cbArea = new ComboBox();
            label3 = new Label();
            btnRegistrar = new Button();
            bntCancel = new Button();
            cbLevel = new ComboBox();
            label2 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(164, 172);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(180, 27);
            txtSubjectName.TabIndex = 0;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(164, 132);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(119, 20);
            labelMateria.TabIndex = 1;
            labelMateria.Text = "Nombre Materia";
            // 
            // txtWeekHour
            // 
            txtWeekHour.Location = new Point(486, 168);
            txtWeekHour.Name = "txtWeekHour";
            txtWeekHour.Size = new Size(180, 27);
            txtWeekHour.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(497, 132);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 3;
            label1.Text = "Horas Semanales";
            // 
            // cbArea
            // 
            cbArea.FormattingEnabled = true;
            cbArea.Location = new Point(164, 254);
            cbArea.Name = "cbArea";
            cbArea.Size = new Size(180, 28);
            cbArea.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 216);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 7;
            label3.Text = "Plan";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(509, 377);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(141, 29);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar Materia";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // bntCancel
            // 
            bntCancel.Location = new Point(214, 377);
            bntCancel.Name = "bntCancel";
            bntCancel.Size = new Size(94, 29);
            bntCancel.TabIndex = 9;
            bntCancel.Text = "Cancelar";
            bntCancel.UseVisualStyleBackColor = true;
            // 
            // cbLevel
            // 
            cbLevel.FormattingEnabled = true;
            cbLevel.Location = new Point(486, 254);
            cbLevel.Name = "cbLevel";
            cbLevel.Size = new Size(180, 28);
            cbLevel.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(497, 216);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 5;
            label2.Text = "Nivel";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(950, 27);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.Add;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "add";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.Edit;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "edit";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = Properties.Resources.Delete;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "delete";
            // 
            // frmMateria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 474);
            Controls.Add(toolStrip1);
            Controls.Add(cbLevel);
            Controls.Add(bntCancel);
            Controls.Add(btnRegistrar);
            Controls.Add(label3);
            Controls.Add(cbArea);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtWeekHour);
            Controls.Add(labelMateria);
            Controls.Add(txtSubjectName);
            Name = "frmMateria";
            Text = "frmMateria";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSubjectName;
        private Label labelMateria;
        private TextBox txtWeekHour;
        private Label label1;
        private TextBox txtTotalHour;
        private ComboBox cbArea;
        private Label label3;
        private Button btnRegistrar;
        private Button bntCancel;
        private ComboBox cbLevel;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
    }
}