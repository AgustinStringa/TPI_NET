namespace UI.Desktop.Subject
{
    partial class SubjectList
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
            lstCorrelativeSubjects = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lstCorrelativeSubjects
            // 
            lstCorrelativeSubjects.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lstCorrelativeSubjects.FullRowSelect = true;
            lstCorrelativeSubjects.Location = new Point(12, 33);
            lstCorrelativeSubjects.Name = "lstCorrelativeSubjects";
            lstCorrelativeSubjects.Size = new Size(409, 253);
            lstCorrelativeSubjects.TabIndex = 0;
            lstCorrelativeSubjects.UseCompatibleStateImageBehavior = false;
            lstCorrelativeSubjects.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nombre";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nivel";
            columnHeader2.Width = 100;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(346, 292);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // SubjectList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 327);
            Controls.Add(btnAdd);
            Controls.Add(lstCorrelativeSubjects);
            Name = "SubjectList";
            Text = "SubjectList";
            ResumeLayout(false);
        }

        #endregion

        private ListView lstCorrelativeSubjects;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnAdd;
    }
}