namespace UI.Desktop.Commission
{
    partial class frmActionCommission
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
            panel1 = new Panel();
            btnActionCommission = new Button();
            txtCommissionYear = new TextBox();
            txtCommissionIdCurriculum = new TextBox();
            txtId = new TextBox();
            txtCommissionDescription = new TextBox();
            lblIdCurriculum = new Label();
            lblYear = new Label();
            lblId = new Label();
            lblDescription = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActionCommission);
            panel1.Controls.Add(txtCommissionYear);
            panel1.Controls.Add(txtCommissionIdCurriculum);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(txtCommissionDescription);
            panel1.Controls.Add(lblIdCurriculum);
            panel1.Controls.Add(lblYear);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(lblDescription);
            panel1.Location = new Point(24, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 298);
            panel1.TabIndex = 0;
            // 
            // btnActionCommission
            // 
            btnActionCommission.Location = new Point(281, 157);
            btnActionCommission.Name = "btnActionCommission";
            btnActionCommission.Size = new Size(128, 23);
            btnActionCommission.TabIndex = 8;
            btnActionCommission.Text = "Crear comisión";
            btnActionCommission.UseVisualStyleBackColor = true;
            btnActionCommission.Click += btnActionCommission_Click;
            // 
            // txtCommissionYear
            // 
            txtCommissionYear.Location = new Point(112, 138);
            txtCommissionYear.Name = "txtCommissionYear";
            txtCommissionYear.Size = new Size(100, 23);
            txtCommissionYear.TabIndex = 7;
            // 
            // txtCommissionIdCurriculum
            // 
            txtCommissionIdCurriculum.Location = new Point(112, 191);
            txtCommissionIdCurriculum.Name = "txtCommissionIdCurriculum";
            txtCommissionIdCurriculum.Size = new Size(100, 23);
            txtCommissionIdCurriculum.TabIndex = 6;
            // 
            // txtId
            // 
            txtId.Location = new Point(112, 85);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            // 
            // txtCommissionDescription
            // 
            txtCommissionDescription.Location = new Point(112, 42);
            txtCommissionDescription.Name = "txtCommissionDescription";
            txtCommissionDescription.Size = new Size(297, 23);
            txtCommissionDescription.TabIndex = 4;
            // 
            // lblIdCurriculum
            // 
            lblIdCurriculum.AutoSize = true;
            lblIdCurriculum.Location = new Point(60, 194);
            lblIdCurriculum.Name = "lblIdCurriculum";
            lblIdCurriculum.Size = new Size(46, 15);
            lblIdCurriculum.TabIndex = 3;
            lblIdCurriculum.Text = "Id Plan:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(74, 143);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(32, 15);
            lblYear.TabIndex = 2;
            lblYear.Text = "Año:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(86, 88);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 1;
            lblId.Text = "Id:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(34, 45);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(72, 15);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Descripción:";
            // 
            // frmActionCommission
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 332);
            Controls.Add(panel1);
            Name = "frmActionCommission";
            Text = "Crear Comisión";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblId;
        private Label lblDescription;
        private Label lblIdCurriculum;
        private Label lblYear;
        private TextBox txtId;
        private TextBox txtCommissionDescription;
        private TextBox txtCommissionYear;
        private TextBox txtCommissionIdCurriculum;
        private Button btnActionCommission;
    }
}