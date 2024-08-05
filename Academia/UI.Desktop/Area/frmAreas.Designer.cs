namespace UI.Desktop.Area
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
            colorDialog1 = new ColorDialog();
            lstvAreas = new ListView();
            idArea = new ColumnHeader();
            Description = new ColumnHeader();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtSearchArea = new TextBox();
            lblOutputArea = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAdd, tsbtnEdit, tsbtnRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            tsbtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAdd.Image = Properties.Resources.Add;
            tsbtnAdd.ImageTransparentColor = Color.Magenta;
            tsbtnAdd.Name = "tsbtnAdd";
            tsbtnAdd.Size = new Size(24, 24);
            tsbtnAdd.Text = "Crear Especialidad";
            tsbtnAdd.Click += tsbtnAdd_Click;
            // 
            // tsbtnEdit
            // 
            tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEdit.Image = Properties.Resources.Edit;
            tsbtnEdit.ImageTransparentColor = Color.Magenta;
            tsbtnEdit.Name = "tsbtnEdit";
            tsbtnEdit.Size = new Size(24, 24);
            tsbtnEdit.Text = "Editar Especialidad";
            tsbtnEdit.Click += tsbtnEdit_Click;
            // 
            // tsbtnRemove
            // 
            tsbtnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnRemove.Image = Properties.Resources.Delete;
            tsbtnRemove.ImageTransparentColor = Color.Magenta;
            tsbtnRemove.Name = "tsbtnRemove";
            tsbtnRemove.Size = new Size(24, 24);
            tsbtnRemove.Text = "Eliminar Especialidad";
            tsbtnRemove.Click += tsbtnRemove_Click;
            // 
            // dgvAreas
            // 
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAreas.Location = new Point(54, 342);
            dgvAreas.Name = "dgvAreas";
            dgvAreas.RowHeadersWidth = 51;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.Size = new Size(678, 150);
            dgvAreas.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 324);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // lstvAreas
            // 
            lstvAreas.Columns.AddRange(new ColumnHeader[] { idArea, Description });
            lstvAreas.FullRowSelect = true;
            lstvAreas.GridLines = true;
            lstvAreas.Location = new Point(54, 128);
            lstvAreas.Name = "lstvAreas";
            lstvAreas.Size = new Size(678, 173);
            lstvAreas.TabIndex = 3;
            lstvAreas.UseCompatibleStateImageBehavior = false;
            lstvAreas.View = View.Details;
            // 
            // idArea
            // 
            idArea.Text = "Id especialidad";
            idArea.Width = 200;
            // 
            // Description
            // 
            Description.Text = "Descripcion";
            Description.Width = 200;
            // 
            // txtSearchArea
            // 
            txtSearchArea.Location = new Point(54, 86);
            txtSearchArea.Name = "txtSearchArea";
            txtSearchArea.Size = new Size(232, 23);
            txtSearchArea.TabIndex = 4;
            txtSearchArea.TextChanged += txtSearchArea_TextChanged;
            // 
            // lblOutputArea
            // 
            lblOutputArea.AutoSize = true;
            lblOutputArea.Location = new Point(128, 514);
            lblOutputArea.Name = "lblOutputArea";
            lblOutputArea.Size = new Size(38, 15);
            lblOutputArea.TabIndex = 5;
            lblOutputArea.Text = "label2";
            // 
            // frmAreas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 664);
            Controls.Add(lblOutputArea);
            Controls.Add(txtSearchArea);
            Controls.Add(lstvAreas);
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


        private ColorDialog colorDialog1;
        private ListView lstvAreas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ColumnHeader idArea;
        private ColumnHeader Description;
        private TextBox txtSearchArea;
        private Label lblOutputArea;
    }
}