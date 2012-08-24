
namespace FluentHtml
{
    public static class TextBuilderExtension
    {
        public static T IsReadOnly<T>(this T inputElementBuilder, bool value) where T : ITextBoxBuilder
        {
            var readOnly = value ? HTMLATTRIBUTE.READONLY : string.Empty;
            inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.READONLY, readOnly);
            return inputElementBuilder;
        }

        public static T EnableAutoComplete<T>(this T inputElementBuilder, bool value) where T : ITextBoxBuilder
        {
            var autoComplete = value ? HTMLATTRIBUTE.ON : HTMLATTRIBUTE.OFF;
            inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.AUTOCOMPLETE, autoComplete);
            return inputElementBuilder;
        }

        public static T WithPlaceholder<T>(this T inputElementBuilder, string value) where T : ITextBoxBuilder
        {
            inputElementBuilder.Html.MergeAttribute("placeholder", value);
            return inputElementBuilder;
        }
    }
}
