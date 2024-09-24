namespace UI.Desktop.Curriculum
{
    partial class FrmCurriculum
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
            lblTitleFrmCurriculum = new Label();
            lstvCurriculum = new ListView();
            idCurriculum = new ColumnHeader();
            Description = new ColumnHeader();
            Area = new ColumnHeader();
            Year = new ColumnHeader();
            Resolution = new ColumnHeader();
            txtSearchCurriculum = new TextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAdd, tsbtnEdit, tsbtnRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            tsbtnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAdd.Image = Properties.Resources.Add;
            tsbtnAdd.ImageTransparentColor = Color.Magenta;
            tsbtnAdd.Name = "tsbtnAdd";
            tsbtnAdd.Size = new Size(23, 22);
            tsbtnAdd.Text = "Crear Plan de Estudios";
            tsbtnAdd.Click += tsbtnAdd_Click;
            // 
            // tsbtnEdit
            // 
            tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEdit.Image = Properties.Resources.Edit;
            tsbtnEdit.ImageTransparentColor = Color.Magenta;
            tsbtnEdit.Name = "tsbtnEdit";
            tsbtnEdit.Size = new Size(23, 22);
            tsbtnEdit.Text = "Editar Plan de Estudios";
            tsbtnEdit.Click += tsbtnEdit_Click;
            // 
            // tsbtnRemove
            // 
            tsbtnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnRemove.Image = Properties.Resources.Delete;
            tsbtnRemove.ImageTransparentColor = Color.Magenta;
            tsbtnRemove.Name = "tsbtnRemove";
            tsbtnRemove.Size = new Size(23, 22);
            tsbtnRemove.Text = "Eliminar Plan de Estudios";
            tsbtnRemove.Click += tsbtnRemove_Click;
            // 
            // lblTitleFrmCurriculum
            // 
            lblTitleFrmCurriculum.AutoSize = true;
            lblTitleFrmCurriculum.Font = new Font("Segoe UI", 12F);
            lblTitleFrmCurriculum.Location = new Point(37, 64);
            lblTitleFrmCurriculum.Name = "lblTitleFrmCurriculum";
            lblTitleFrmCurriculum.Size = new Size(131, 21);
            lblTitleFrmCurriculum.TabIndex = 4;
            lblTitleFrmCurriculum.Text = "Planes de Estudio";
            // 
            // lstvCurriculum
            // 
            lstvCurriculum.Columns.AddRange(new ColumnHeader[] { idCurriculum, Description, Area, Year, Resolution });
            lstvCurriculum.FullRowSelect = true;
            lstvCurriculum.GridLines = true;
            lstvCurriculum.Location = new Point(37, 142);
            lstvCurriculum.Name = "lstvCurriculum";
            lstvCurriculum.Size = new Size(701, 335);
            lstvCurriculum.TabIndex = 5;
            lstvCurriculum.UseCompatibleStateImageBehavior = false;
            lstvCurriculum.View = View.Details;
            // 
            // idCurriculum
            // 
            idCurriculum.Text = "Id plan de estudio";
            idCurriculum.Width = 150;
            // 
            // Description
            // 
            Description.Text = "Descripcion";
            Description.Width = 150;
            // 
            // Area
            // 
            Area.Text = "Especialidad";
            Area.Width = 100;
            // 
            // Year
            // 
            Year.Text = "Año";
            // 
            // Resolution
            // 
            Resolution.Text = "Resolucion";
            Resolution.Width = 200;
            // 
            // txtSearchCurriculum
            // 
            txtSearchCurriculum.Location = new Point(37, 98);
            txtSearchCurriculum.Name = "txtSearchCurriculum";
            txtSearchCurriculum.PlaceholderText = "Search...";
            txtSearchCurriculum.Size = new Size(250, 23);
            txtSearchCurriculum.TabIndex = 6;
            txtSearchCurriculum.TextChanged += txtSearchCurriculum_TextChanged;
            // 
            // FrmCurriculum
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(txtSearchCurriculum);
            Controls.Add(lstvCurriculum);
            Controls.Add(lblTitleFrmCurriculum);
            Controls.Add(toolStrip1);
            Name = "FrmCurriculum";
            Text = "Planes de Estudio";
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
        private Label lblTitleFrmCurriculum;
        private ListView lstvCurriculum;
        private ColumnHeader idCurriculum;
        private ColumnHeader Description;
        private ColumnHeader Area;
        private ColumnHeader Year;
        private ColumnHeader Resolution;
        private TextBox txtSearchCurriculum;
    }
}