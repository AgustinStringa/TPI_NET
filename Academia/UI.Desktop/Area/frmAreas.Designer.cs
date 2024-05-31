namespace UI.Desktop
{
    partial class frmAreas
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
            dgvAreas = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAdd, tsbtnEdit, tsbtnRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            tsbtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAdd.Image = Properties.Resources.Add;
            tsbtnAdd.ImageTransparentColor = Color.Magenta;
            tsbtnAdd.Name = "tsbtnAdd";
            tsbtnAdd.Size = new Size(23, 22);
            tsbtnAdd.Text = "Crear Especialidad";
            tsbtnAdd.Click += tsbtnAdd_Click;
            // 
            // tsbtnEdit
            // 
            tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEdit.Image = Properties.Resources.Edit;
            tsbtnEdit.ImageTransparentColor = Color.Magenta;
            tsbtnEdit.Name = "tsbtnEdit";
            tsbtnEdit.Size = new Size(23, 22);
            tsbtnEdit.Text = "Editar Especialidad";
            tsbtnEdit.Click += tsbtnEdit_Click;
            // 
            // tsbtnRemove
            // 
            tsbtnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnRemove.Image = Properties.Resources.Delete;
            tsbtnRemove.ImageTransparentColor = Color.Magenta;
            tsbtnRemove.Name = "tsbtnRemove";
            tsbtnRemove.Size = new Size(23, 22);
            tsbtnRemove.Text = "Eliminar Especialidad";
            tsbtnRemove.Click += tsbtnRemove_Click;
            // 
            // dgvAreas
            // 
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAreas.Location = new Point(54, 99);
            dgvAreas.Name = "dgvAreas";
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.Size = new Size(678, 150);
            dgvAreas.TabIndex = 1;
            dgvAreas.SelectionChanged += dgvAreas_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 67);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(508, 57);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmAreas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dgvAreas);
            Controls.Add(toolStrip1);
            Name = "frmAreas";
            Text = "Especialidades";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbtnAdd;
        private DataGridView dgvAreas;
        private ToolStripButton tsbtnEdit;
        private ToolStripButton tsbtnRemove;
        private Label label1;
        private Button button1;
    }
}