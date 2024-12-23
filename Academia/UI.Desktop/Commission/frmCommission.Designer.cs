﻿namespace UI.Desktop.Commission
{
    partial class FrmCommissions
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
			txtSearch = new TextBox();
			lstvCommission = new ListView();
			idCurriculum = new ColumnHeader();
			level = new ColumnHeader();
			description = new ColumnHeader();
			toolStrip1.SuspendLayout();
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
			tsbtnAdd.Text = "Crear Comisión";
			tsbtnAdd.Click += tsbtnAdd_Click;
			// 
			// tsbtnEdit
			// 
			tsbtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
			tsbtnEdit.Image = Properties.Resources.Edit;
			tsbtnEdit.ImageTransparentColor = Color.Magenta;
			tsbtnEdit.Name = "tsbtnEdit";
			tsbtnEdit.Size = new Size(23, 22);
			tsbtnEdit.Text = "Editar Comisión";
			tsbtnEdit.Click += tsbtnEdit_Click;
			// 
			// tsbtnRemove
			// 
			tsbtnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
			tsbtnRemove.Image = Properties.Resources.Delete;
			tsbtnRemove.ImageTransparentColor = Color.Magenta;
			tsbtnRemove.Name = "tsbtnRemove";
			tsbtnRemove.Size = new Size(23, 22);
			tsbtnRemove.Text = "Eliminar Comisión";
			tsbtnRemove.Click += tsbtnRemove_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(61, 51);
			label1.Name = "label1";
			label1.Size = new Size(91, 21);
			label1.TabIndex = 5;
			label1.Text = "Comisiones";
			// 
			// txtSearch
			// 
			txtSearch.Location = new Point(61, 90);
			txtSearch.Name = "txtSearch";
			txtSearch.PlaceholderText = " Buscar";
			txtSearch.Size = new Size(250, 23);
			txtSearch.TabIndex = 7;
			txtSearch.TextChanged += txtSearch_TextChanged;
			// 
			// lstvCommission
			// 
			lstvCommission.Columns.AddRange(new ColumnHeader[] { idCurriculum, level, description });
			lstvCommission.FullRowSelect = true;
			lstvCommission.GridLines = true;
			lstvCommission.Location = new Point(50, 137);
			lstvCommission.Name = "lstvCommission";
			lstvCommission.Size = new Size(701, 256);
			lstvCommission.TabIndex = 8;
			lstvCommission.UseCompatibleStateImageBehavior = false;
			lstvCommission.View = View.Details;
			// 
			// idCurriculum
			// 
			idCurriculum.Text = "Plan de estudio";
			idCurriculum.Width = 200;
			// 
			// level
			// 
			level.Text = "Nivel";
			level.Width = 150;
			// 
			// description
			// 
			description.Text = "Descripcion";
			description.Width = 150;
			// 
			// FrmCommissions
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(lstvCommission);
			Controls.Add(txtSearch);
			Controls.Add(label1);
			Controls.Add(toolStrip1);
			Name = "FrmCommissions";
			Text = "Comisiones";
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
        private TextBox txtSearch;
        private ListView lstvCommission;
        private ColumnHeader level;
        private ColumnHeader description;
        private ColumnHeader idCurriculum;
    }
}