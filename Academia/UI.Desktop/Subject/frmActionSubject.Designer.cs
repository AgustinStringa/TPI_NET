namespace UI.Desktop.Subject
{
    partial class FrmActionSubject
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
            txtDescription = new TextBox();
            label1 = new Label();
            txtWeeklyHours = new TextBox();
            label2 = new Label();
            cbCurriculums = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            label5 = new Label();
            txtTotalHours = new TextBox();
            lstCorrelativesParent = new ListBox();
            label6 = new Label();
            label7 = new Label();
            lstCorrelativesChildren = new ListBox();
            btnAddCorrelativeParent = new Button();
            btnRemoveCorrelativeParent = new Button();
            btnRemoveCorrelativeChildren = new Button();
            btnAddCorrelativeChildren = new Button();
            numLevel = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numLevel).BeginInit();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(134, 152);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(221, 27);
            txtDescription.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 117);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre Materia";
            // 
            // txtWeeklyHours
            // 
            txtWeeklyHours.Location = new Point(134, 241);
            txtWeeklyHours.Name = "txtWeeklyHours";
            txtWeeklyHours.Size = new Size(221, 27);
            txtWeeklyHours.TabIndex = 2;
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
            cbCurriculums.Location = new Point(427, 152);
            cbCurriculums.Name = "cbCurriculums";
            cbCurriculums.Size = new Size(221, 28);
            cbCurriculums.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(427, 117);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 5;
            label3.Text = "Plan de Estudio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(427, 205);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 7;
            label4.Text = "Nivel";
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(0, 123, 255);
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI", 12F);
            btnAccept.ForeColor = SystemColors.ButtonHighlight;
            btnAccept.Location = new Point(1105, 493);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(181, 67);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Registrar Materia";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(197, 493);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(190, 67);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar Operacion";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(134, 295);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 11;
            label5.Text = "Horas totales";
            // 
            // txtTotalHours
            // 
            txtTotalHours.Location = new Point(134, 331);
            txtTotalHours.Name = "txtTotalHours";
            txtTotalHours.Size = new Size(221, 27);
            txtTotalHours.TabIndex = 10;
            // 
            // lstCorrelativesParent
            // 
            lstCorrelativesParent.FormattingEnabled = true;
            lstCorrelativesParent.Location = new Point(851, 147);
            lstCorrelativesParent.Margin = new Padding(3, 4, 3, 4);
            lstCorrelativesParent.Name = "lstCorrelativesParent";
            lstCorrelativesParent.Size = new Size(434, 124);
            lstCorrelativesParent.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(728, 123);
            label6.Name = "label6";
            label6.Size = new Size(128, 20);
            label6.TabIndex = 13;
            label6.Text = "Correlativas Padre";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(728, 285);
            label7.Name = "label7";
            label7.Size = new Size(118, 20);
            label7.TabIndex = 15;
            label7.Text = "Correlativas Hija";
            // 
            // lstCorrelativesChildren
            // 
            lstCorrelativesChildren.FormattingEnabled = true;
            lstCorrelativesChildren.Location = new Point(851, 309);
            lstCorrelativesChildren.Margin = new Padding(3, 4, 3, 4);
            lstCorrelativesChildren.Name = "lstCorrelativesChildren";
            lstCorrelativesChildren.Size = new Size(434, 124);
            lstCorrelativesChildren.TabIndex = 14;
            // 
            // btnAddCorrelativeParent
            // 
            btnAddCorrelativeParent.Image = Properties.Resources.Add;
            btnAddCorrelativeParent.Location = new Point(728, 152);
            btnAddCorrelativeParent.Margin = new Padding(3, 4, 3, 4);
            btnAddCorrelativeParent.Name = "btnAddCorrelativeParent";
            btnAddCorrelativeParent.Size = new Size(86, 35);
            btnAddCorrelativeParent.TabIndex = 16;
            btnAddCorrelativeParent.UseVisualStyleBackColor = true;
            btnAddCorrelativeParent.Click += btnAddCorrelativeParent_Click;
            // 
            // btnRemoveCorrelativeParent
            // 
            btnRemoveCorrelativeParent.Image = Properties.Resources.Delete;
            btnRemoveCorrelativeParent.Location = new Point(728, 195);
            btnRemoveCorrelativeParent.Margin = new Padding(3, 4, 3, 4);
            btnRemoveCorrelativeParent.Name = "btnRemoveCorrelativeParent";
            btnRemoveCorrelativeParent.Size = new Size(86, 36);
            btnRemoveCorrelativeParent.TabIndex = 17;
            btnRemoveCorrelativeParent.UseVisualStyleBackColor = true;
            btnRemoveCorrelativeParent.Click += btnRemoveCorrelativeParent_Click;
            // 
            // btnRemoveCorrelativeChildren
            // 
            btnRemoveCorrelativeChildren.Image = Properties.Resources.Delete;
            btnRemoveCorrelativeChildren.Location = new Point(728, 357);
            btnRemoveCorrelativeChildren.Margin = new Padding(3, 4, 3, 4);
            btnRemoveCorrelativeChildren.Name = "btnRemoveCorrelativeChildren";
            btnRemoveCorrelativeChildren.Size = new Size(86, 36);
            btnRemoveCorrelativeChildren.TabIndex = 19;
            btnRemoveCorrelativeChildren.UseVisualStyleBackColor = true;
            btnRemoveCorrelativeChildren.Click += btnRemoveCorrelativeChildren_Click;
            // 
            // btnAddCorrelativeChildren
            // 
            btnAddCorrelativeChildren.Image = Properties.Resources.Add;
            btnAddCorrelativeChildren.Location = new Point(728, 315);
            btnAddCorrelativeChildren.Margin = new Padding(3, 4, 3, 4);
            btnAddCorrelativeChildren.Name = "btnAddCorrelativeChildren";
            btnAddCorrelativeChildren.Size = new Size(86, 35);
            btnAddCorrelativeChildren.TabIndex = 18;
            btnAddCorrelativeChildren.UseVisualStyleBackColor = true;
            btnAddCorrelativeChildren.Click += btnAddCorrelativeChildren_Click;
            // 
            // numLevel
            // 
            numLevel.Location = new Point(427, 243);
            numLevel.Margin = new Padding(3, 4, 3, 4);
            numLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLevel.Name = "numLevel";
            numLevel.Size = new Size(222, 27);
            numLevel.TabIndex = 20;
            numLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FrmActionSubject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 575);
            Controls.Add(numLevel);
            Controls.Add(btnRemoveCorrelativeChildren);
            Controls.Add(btnAddCorrelativeChildren);
            Controls.Add(btnRemoveCorrelativeParent);
            Controls.Add(btnAddCorrelativeParent);
            Controls.Add(label7);
            Controls.Add(lstCorrelativesChildren);
            Controls.Add(label6);
            Controls.Add(lstCorrelativesParent);
            Controls.Add(label5);
            Controls.Add(txtTotalHours);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbCurriculums);
            Controls.Add(label2);
            Controls.Add(txtWeeklyHours);
            Controls.Add(label1);
            Controls.Add(txtDescription);
            Name = "FrmActionSubject";
            Text = "frmActionArea";
            ((System.ComponentModel.ISupportInitialize)numLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescription;
        private Label label1;
        private TextBox txtWeeklyHours;
        private Label label2;
        private ComboBox cbCurriculums;
        private Label label3;
        private Label label4;
        private Button btnAccept;
        private Button btnCancel;
        private Label label5;
        private TextBox txtTotalHours;
        private ListBox lstCorrelativesParent;
        private Label label6;
        private Label label7;
        private ListBox lstCorrelativesChildren;
        private Button btnAddCorrelativeParent;
        private Button btnRemoveCorrelativeParent;
        private Button btnRemoveCorrelativeChildren;
        private Button btnAddCorrelativeChildren;
        private NumericUpDown numLevel;
    }
}