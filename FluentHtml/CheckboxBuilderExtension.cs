using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHtml
{
    public static class CheckboxBuilderExtension
    {
        public static T Checked<T>(this T checkBoxBuilder, bool value) where T : ICheckboxBuilder
        {
            var Checked = value ? HTMLATTRIBUTE.CHECKED : string.Empty;
            checkBoxBuilder.Html.MergeAttribute(HTMLATTRIBUTE.CHECKED, Checked);
            return checkBoxBuilder;
        }
    }
}
