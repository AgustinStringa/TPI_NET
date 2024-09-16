using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Desktop
{
    public class Utilities
    {
        public static async void LoadAreas(ComboBox cb) {
            try
            {
                var service = new Domain.Services.AreaService();
                cb.DataSource = service.GetAll();
                cb.ValueMember = "Id";
                cb.DisplayMember = "Description";
                cb.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async void LoadAreas(IEnumerable<Domain.Model.Area> areasList ,ComboBox cb)
        {
            try
            {
                var service = new Domain.Services.AreaService();
                areasList = service.GetAll();
                cb.DataSource = areasList;
                cb.ValueMember = "Id";
                cb.DisplayMember = "Description";
                cb.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async void LoadCurriculums(IEnumerable<Domain.Model.Curriculum> curriculums, ComboBox cb, int val)
        {
            try
            {
                var service = new Domain.Services.CurriculumService();
                curriculums =  await service.GetAll();
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

        public static async void LoadCurriculums(IEnumerable<Domain.Model.Curriculum> curriculums, ComboBox cb)
        {
            try
            {
                var service = new Domain.Services.CurriculumService();
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


        public static async void LoadCurriculums(ComboBox cb)
        {
            try
            {
                var service = new Domain.Services.CurriculumService();
                var curriculums = await service.GetAll();
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

        public static async void LoadCurriculums(ComboBox cb, Domain.Model.Curriculum curr)
        {
            try
            {
                var service = new Domain.Services.CurriculumService();
                var curriculums = await service.GetAll();
                cb.DataSource = curriculums;
                cb.ValueMember = "Id";
                cb.DisplayMember = "Description";
                cb.SelectedValue = curr.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
