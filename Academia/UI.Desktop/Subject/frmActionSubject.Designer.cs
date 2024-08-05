namespace UI.Desktop.Subject
{
    partial class frmActionSubject
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
            txtName = new TextBox();
            label1 = new Label();
            txtWeekHours = new TextBox();
            label2 = new Label();
            cbCurriculums = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cbLevel = new ComboBox();
            btnAccept = new Button();
            btnDecline = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(134, 152);
            txtName.Name = "txtName";
            txtName.Size = new Size(221, 27);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 118);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre Materia";
            // 
            // txtWeekHours
            // 
            txtWeekHours.Location = new Point(134, 241);
            txtWeekHours.Name = "txtWeekHours";
            txtWeekHours.Size = new Size(221, 27);
            txtWeekHours.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 205);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 3;
            label2.Text = "Horas semanales";
            // 
            // cbCurriculums
            // 
            cbCurriculums.FormattingEnabled = true;
            cbCurriculums.Location = new Point(428, 152);
            cbCurriculums.Name = "cbCurriculums";
            cbCurriculums.Size = new Size(221, 28);
            cbCurriculums.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(428, 118);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 5;
            label3.Text = "Plan de Estudio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(428, 206);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 7;
            label4.Text = "Nivel";
            // 
            // cbLevel
            // 
            cbLevel.FormattingEnabled = true;
            cbLevel.Location = new Point(428, 240);
            cbLevel.Name = "cbLevel";
            cbLevel.Size = new Size(221, 28);
            cbLevel.TabIndex = 6;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(468, 333);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(159, 29);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Registrar Materia";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnDecline
            // 
            btnDecline.Location = new Point(196, 333);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(159, 29);
            btnDecline.TabIndex = 9;
            btnDecline.Text = "Cancelar Operacion";
            btnDecline.UseVisualStyleBackColor = true;
            // 
            // frmActionSubject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(label4);
            Controls.Add(cbLevel);
            Controls.Add(label3);
            Controls.Add(cbCurriculums);
            Controls.Add(label2);
            Controls.Add(txtWeekHours);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "frmActionSubject";
            Text = "frmActionArea";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private TextBox txtWeekHours;
        private Label label2;
        private ComboBox cbCurriculums;
        private Label label3;
        private Label label4;
        private ComboBox cbLevel;
        private Button btnAccept;
        private Button btnDecline;
    }
}