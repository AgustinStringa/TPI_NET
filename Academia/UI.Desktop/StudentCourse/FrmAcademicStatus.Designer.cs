namespace UI.Desktop
{
    partial class FrmAcademicStatus
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
            lblName = new Label();
            listView1 = new ListView();
            Materia = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 62);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Estado Académico";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(51, 90);
            lblName.Name = "lblName";
            lblName.Size = new Size(97, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre Alumno";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Materia, columnHeader1, columnHeader2 });
            listView1.Location = new Point(51, 131);
            listView1.Name = "listView1";
            listView1.Size = new Size(683, 97);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Materia
            // 
            Materia.Text = "Materia";
            Materia.Width = 350;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Estado";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nota";
            columnHeader2.Width = 100;
            // 
            // frmMisMaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(lblName);
            Controls.Add(label1);
            Name = "frmMisMaterias";
            Text = "frmMisMaterias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblName;
        private ListView listView1;
        private ColumnHeader Materia;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}