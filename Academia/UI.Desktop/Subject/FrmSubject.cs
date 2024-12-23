﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;
using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using ClientService.Subject;

namespace UI.Desktop.Subject
{
	public partial class FrmSubject : Form
	{
		private IEnumerable<ApplicationCore.Model.Subject> subjects;
		private List<ApplicationCore.Model.Curriculum> curriculums = new List<ApplicationCore.Model.Curriculum>();
		private string searchText = "";
		private IServiceProvider serviceProvider;
		private ISubjectService subjectService;

		public FrmSubject(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.serviceProvider = serviceProvider;
			this.subjectService = serviceProvider.GetRequiredService<ISubjectService>();
			Utilities.StyleListViewHeader(lstSubjects, Color.FromArgb(184, 218, 255));
			LoadSubjects();
		}
		#region events
		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionSubject frm = new FrmActionSubject(Mode.Create, this.serviceProvider);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadSubjects();
			}
		}
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (lstSubjects.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Subject selectedSubject = (ApplicationCore.Model.Subject)lstSubjects.SelectedItems[0].Tag;
				FrmActionSubject frm = new FrmActionSubject(Mode.Edit, selectedSubject, this.serviceProvider);
				var result = frm.ShowDialog();
				if (result == DialogResult.OK)
				{
					LoadSubjects();
				}
			}
			else
			{
				MessageBox.Show("Seleccione una materia antes de editar", "Editar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private async void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (lstSubjects.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Subject selectedSubject = (ApplicationCore.Model.Subject)lstSubjects.SelectedItems[0].Tag;
				if (Utilities.ConfirmDelete($"la materia '{selectedSubject.Description}'") != DialogResult.OK) return;
				await subjectService.Delete(selectedSubject.Id);
				LoadSubjects();

			}
			else
			{
				MessageBox.Show("Seleccione una materia antes de eliminar", "Eliminar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void txtSearchSubject_TextChanged(object sender, EventArgs e)
		{
			ApplyFilters();
		}
		private void cbCurriculum_SelectedValueChanged(object sender, EventArgs e)
		{
			ApplyFilters();
		}
		private void btnResetFilters_Click(object sender, EventArgs e)
		{
			this.txtSearchSubject.Text = "";
			this.cbCurriculum.SelectedIndex = 0;
			AdaptSubjectsToListView(this.subjects);
		}
		#endregion

		#region Methods
		private async void LoadSubjects()
		{
			try
			{
				lstSubjects.Enabled = false;
				subjects = await subjectService.GetAllWithCurriculum();
				AdaptSubjectsToListView(subjects);
				LoadCurriculumFilter();
			}
			catch (Exception)
			{
				MessageBox.Show("Error al cargar las materias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				lstSubjects.Enabled = true;
			}


		}
		private void LoadCurriculumFilter()
		{
			this.curriculums.Clear();
			this.curriculums.Add(new ApplicationCore.Model.Curriculum { Description = "Todos los planes" });
			this.curriculums.AddRange(subjects.Select(s => s.Curriculum).DistinctBy(c => c.Description).ToList());
			cbCurriculum.DataSource = null;
			cbCurriculum.DataSource = curriculums;
			cbCurriculum.Refresh();
			cbCurriculum.ValueMember = "Id";
			cbCurriculum.DisplayMember = "Description";
		}
		private void AdaptSubjectsToListView(IEnumerable<ApplicationCore.Model.Subject> subjectList)
		{
			lstSubjects.Items.Clear();
			foreach (ApplicationCore.Model.Subject item in subjectList)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Description);
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Curriculum.Description);
				nuevoItem.SubItems.Add(item.Level.ToString());
				nuevoItem.SubItems.Add(item.WeeklyHours.ToString());
				nuevoItem.SubItems.Add(item.TotalHours.ToString());
				lstSubjects.Items.Add(nuevoItem);
			}
			lstSubjects.Refresh();
		}
		private void ApplyFilters()
		{
			if (this.subjects == null || this.subjects.Count() <= 0)
			{
				return;
			}
			var filteredSubjects = this.subjects;
			this.searchText = txtSearchSubject.Text;
			filteredSubjects = filteredSubjects.Where(s => Utilities.DeleteDiacritic(s.Description.ToLower()).Contains(Utilities.DeleteDiacritic(this.searchText.ToLower())));
			if (cbCurriculum.SelectedItem != null && cbCurriculum.SelectedIndex != 0)
			{
				filteredSubjects = filteredSubjects.Where(s => s.IdCurriculum == ((ApplicationCore.Model.Curriculum)cbCurriculum.SelectedItem).Id);
			}
			AdaptSubjectsToListView(filteredSubjects);
		}
		#endregion
	}
}
