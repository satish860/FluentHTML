
namespace FluentHtml
{
    public static class InputElementBuilderExtension
    {
        public static T Value<T>(this T inputElementBuilder, string value) where T : IInputElementBuilder
        {
            inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.VALUE, value);
            return inputElementBuilder;
        }

        public static T Disabled<T>(this T inputElementBuilder, bool value) where T : IInputElementBuilder
        {
            if (value)
                inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.DISABLED, HTMLATTRIBUTE.DISABLED);
            return inputElementBuilder;
        }

        public static T AutoFocus<T>(this T inputElementBuilder, bool value) where T : IInputElementBuilder
        {
            if (value)
                inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.AUTOFOCUS, HTMLATTRIBUTE.AUTOFOCUS);
            return inputElementBuilder;
        }






    }
}
