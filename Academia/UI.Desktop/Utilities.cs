using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;

namespace UI.Desktop
{
	public class Utilities
	{
		public static async void LoadAreas(ComboBox cb)
		{
			try
			{
				var service = new ApplicationCore.Services.AreaService();
				var areas = await service.GetAll();
				if (areas.Count() > 0)
				{
					cb.DataSource = areas;
					cb.ValueMember = "Id";
					cb.DisplayMember = "Description";
					cb.SelectedIndex = 0;

				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static async void LoadAreas(IEnumerable<ApplicationCore.Model.Area> areasList, ComboBox cb)
		{
			try
			{
				var service = new ApplicationCore.Services.AreaService();
				areasList = await service.GetAll();
				if (areasList.Count() > 0)
				{
					cb.DataSource = areasList;
					cb.ValueMember = "Id";
					cb.DisplayMember = "Description";
					cb.SelectedIndex = 0;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static async void LoadCurriculums(IEnumerable<ApplicationCore.Model.Curriculum> curriculums, ComboBox cb, int val)
		{
			try
			{
				var service = new ApplicationCore.Services.CurriculumService();
				curriculums = await service.GetAll();
				cb.DataSource = curriculums;
				cb.ValueMember = "Id";
				cb.DisplayMember = "Description";
				cb.SelectedValue = val;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static async void LoadCurriculums(IEnumerable<ApplicationCore.Model.Curriculum> curriculums, ComboBox cb)
		{
			try
			{
				var service = new ApplicationCore.Services.CurriculumService();
				curriculums = await service.GetAll();
				cb.DataSource = curriculums;
				cb.ValueMember = "Id";
				cb.DisplayMember = "Description";
				cb.SelectedIndex = 0;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static string EncodePassword(string password)
		{

			byte[] messageBytes = Encoding.UTF8.GetBytes(password);
			byte[] hashValue = SHA256.HashData(messageBytes);
			return Convert.ToHexString(hashValue);
		}

		public static string DeleteDiacritic(string text)
		{

			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}
