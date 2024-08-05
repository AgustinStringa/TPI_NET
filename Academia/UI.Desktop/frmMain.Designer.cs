﻿namespace UI.Desktop
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
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            crearUsuarioToolStripMenuItem1 = new ToolStripMenuItem();
            alumnosToolStripMenuItem = new ToolStripMenuItem();
            docentesToolStripMenuItem = new ToolStripMenuItem();
            administrativosToolStripMenuItem = new ToolStripMenuItem();
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            planesDeEstudioToolStripMenuItem = new ToolStripMenuItem();
            profesoresToolStripMenuItem = new ToolStripMenuItem();
            materiasToolStripMenuItem = new ToolStripMenuItem();
            comisionesToolStripMenuItem = new ToolStripMenuItem();
            cursosToolStripMenuItem = new ToolStripMenuItem();
            crearUsuarioToolStripMenuItem = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 

            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, usuariosToolStripMenuItem, especialidadesToolStripMenuItem, planesDeEstudioToolStripMenuItem, profesoresToolStripMenuItem, materiasToolStripMenuItem, comisionesToolStripMenuItem, cursosToolStripMenuItem, crearUsuarioToolStripMenuItem });

            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Padding = new Padding(7, 3, 0, 3);
            mnsPrincipal.Size = new Size(914, 30);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { frmSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(73, 24);
            mnuArchivo.Text = "Archivo";
            // 
            // frmSalir
            // 
            frmSalir.Name = "frmSalir";
            frmSalir.Size = new Size(224, 26);
            frmSalir.Text = "Salir";
            frmSalir.Click += frmSalir_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { crearUsuarioToolStripMenuItem1, alumnosToolStripMenuItem, docentesToolStripMenuItem, administrativosToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // crearUsuarioToolStripMenuItem1
            // 
            crearUsuarioToolStripMenuItem1.Name = "crearUsuarioToolStripMenuItem1";
            crearUsuarioToolStripMenuItem1.Size = new Size(180, 22);
            crearUsuarioToolStripMenuItem1.Text = "Crear Usuario";
            crearUsuarioToolStripMenuItem1.Click += crearUsuarioToolStripMenuItem_Click;
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";

            alumnosToolStripMenuItem.Size = new Size(180, 22);

            alumnosToolStripMenuItem.Text = "Alumnos";
            alumnosToolStripMenuItem.Click += alumnosToolStripMenuItem_Click;
            // 
            // docentesToolStripMenuItem
            // 
            docentesToolStripMenuItem.Name = "docentesToolStripMenuItem";
            docentesToolStripMenuItem.Size = new Size(180, 22);
            docentesToolStripMenuItem.Text = "Docentes";
            // 
            // administrativosToolStripMenuItem
            // 
            administrativosToolStripMenuItem.Name = "administrativosToolStripMenuItem";
            administrativosToolStripMenuItem.Size = new Size(180, 22);
            administrativosToolStripMenuItem.Text = "Administrativos";
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(121, 24);
            especialidadesToolStripMenuItem.Text = "Especialidades";
            especialidadesToolStripMenuItem.Click += especialidadesToolStripMenuItem_Click;
            // 
            // planesDeEstudioToolStripMenuItem
            // 
            planesDeEstudioToolStripMenuItem.Name = "planesDeEstudioToolStripMenuItem";
            planesDeEstudioToolStripMenuItem.Size = new Size(139, 24);
            planesDeEstudioToolStripMenuItem.Text = "Planes de Estudio";
            planesDeEstudioToolStripMenuItem.Click += planesDeEstudioToolStripMenuItem_Click;
            // 
            // profesoresToolStripMenuItem
            // 
            profesoresToolStripMenuItem.Name = "profesoresToolStripMenuItem";
            profesoresToolStripMenuItem.Size = new Size(92, 24);
            profesoresToolStripMenuItem.Text = "Profesores";
            // 
            // materiasToolStripMenuItem
            // 
            materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            materiasToolStripMenuItem.Size = new Size(80, 24);
            materiasToolStripMenuItem.Text = "Materias";
            materiasToolStripMenuItem.Click += materiasToolStripMenuItem_Click;
            // 
            // comisionesToolStripMenuItem
            // 
            comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            comisionesToolStripMenuItem.Size = new Size(99, 24);
            comisionesToolStripMenuItem.Text = "Comisiones";
            // 
            // cursosToolStripMenuItem
            // 
            cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            cursosToolStripMenuItem.Size = new Size(66, 24);
            cursosToolStripMenuItem.Text = "Cursos";
            // 
            // crearUsuarioToolStripMenuItem
            // 
            crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            crearUsuarioToolStripMenuItem.Size = new Size(112, 24);
            crearUsuarioToolStripMenuItem.Text = "Crear Usuario";
            crearUsuarioToolStripMenuItem.Click += crearUsuarioToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(mnsPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            Margin = new Padding(3, 4, 3, 4);
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
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem profesoresToolStripMenuItem;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem comisionesToolStripMenuItem;
        private ToolStripMenuItem cursosToolStripMenuItem;
        private ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private ToolStripMenuItem crearUsuarioToolStripMenuItem1;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStripMenuItem docentesToolStripMenuItem;
        private ToolStripMenuItem administrativosToolStripMenuItem;
    }
}