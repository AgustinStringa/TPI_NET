using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
	public partial class FrmInputGrade : Form
	{
		public decimal _currentGrade;
		public FrmInputGrade(decimal currentGrade)
		{
			InitializeComponent();
			_currentGrade = currentGrade;
			txtGrade.Text = _currentGrade.ToString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				_currentGrade = decimal.Parse(txtGrade.Text);
				if (_currentGrade < 0 || _currentGrade > 10)
				{
					lblGradeError.Visible = true;
					lblGradeError.Text = "Ingresa una nota valida";
				}
				else
				{
					lblGradeError.Visible = false;
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception)
			{
				lblGradeError.Visible = true;
				lblGradeError.Text = "Ingresa una nota valida";
			}

		}

		private void txtGrade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSave.PerformClick();
			}
		}
	}
}
