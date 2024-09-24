using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Desktop
{
    public class ListBoxItem
    {
        public string DisplayText { get; set; }
        public ApplicationCore.Model.Correlative Tag { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
