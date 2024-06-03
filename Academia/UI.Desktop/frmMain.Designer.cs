namespace UI.Desktop
{
    partial class frmMain
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
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            frmSalir = new ToolStripMenuItem();
            alumnosToolStripMenuItem = new ToolStripMenuItem();
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            planesDeEstudioToolStripMenuItem = new ToolStripMenuItem();
            profesoresToolStripMenuItem = new ToolStripMenuItem();
            materiasToolStripMenuItem = new ToolStripMenuItem();
            comisionesToolStripMenuItem = new ToolStripMenuItem();
            cursosToolStripMenuItem = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, alumnosToolStripMenuItem, especialidadesToolStripMenuItem, planesDeEstudioToolStripMenuItem, profesoresToolStripMenuItem, materiasToolStripMenuItem, comisionesToolStripMenuItem, cursosToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 24);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { frmSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(60, 20);
            mnuArchivo.Text = "Archivo";
            // 
            // frmSalir
            // 
            frmSalir.Name = "frmSalir";
            frmSalir.Size = new Size(96, 22);
            frmSalir.Text = "Salir";
            frmSalir.Click += frmSalir_Click;
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(67, 20);
            alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(95, 20);
            especialidadesToolStripMenuItem.Text = "Especialidades";
            especialidadesToolStripMenuItem.Click += especialidadesToolStripMenuItem_Click;
            // 
            // planesDeEstudioToolStripMenuItem
            // 
            planesDeEstudioToolStripMenuItem.Name = "planesDeEstudioToolStripMenuItem";
            planesDeEstudioToolStripMenuItem.Size = new Size(111, 20);
            planesDeEstudioToolStripMenuItem.Text = "Planes de Estudio";
            planesDeEstudioToolStripMenuItem.Click += planesDeEstudioToolStripMenuItem_Click;
            // 
            // profesoresToolStripMenuItem
            // 
            profesoresToolStripMenuItem.Name = "profesoresToolStripMenuItem";
            profesoresToolStripMenuItem.Size = new Size(74, 20);
            profesoresToolStripMenuItem.Text = "Profesores";
            // 
            // materiasToolStripMenuItem
            // 
            materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            materiasToolStripMenuItem.Size = new Size(64, 20);
            materiasToolStripMenuItem.Text = "Materias";
            // 
            // comisionesToolStripMenuItem
            // 
            comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            comisionesToolStripMenuItem.Size = new Size(81, 20);
            comisionesToolStripMenuItem.Text = "Comisiones";
            // 
            // cursosToolStripMenuItem
            // 
            cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            cursosToolStripMenuItem.Size = new Size(55, 20);
            cursosToolStripMenuItem.Text = "Cursos";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mnsPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Academia";
            WindowState = FormWindowState.Maximized;
            Shown += frmMain_Shown;
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem frmSalir;
        private ToolStripMenuItem especialidadesToolStripMenuItem;
        private ToolStripMenuItem planesDeEstudioToolStripMenuItem;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStripMenuItem profesoresToolStripMenuItem;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem comisionesToolStripMenuItem;
        private ToolStripMenuItem cursosToolStripMenuItem;
    }
}