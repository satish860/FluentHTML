namespace FluentHtml
{
    public static class CheckboxBuilderExtension
    {
        public static T Checked<T>(this T checkBoxBuilder, bool value) where T : ICheckboxBuilder
        {
            if (value)
                checkBoxBuilder.Html.MergeAttribute(HTMLATTRIBUTE.CHECKED, HTMLATTRIBUTE.CHECKED);
            return checkBoxBuilder;
        }
    }
}