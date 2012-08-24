
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
            var disabled = value ? HTMLATTRIBUTE.DISABLED : string.Empty;
            inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.DISABLED, disabled);
            return inputElementBuilder;
        }

      

        public static T AutoFocus<T>(this T inputElementBuilder, bool value) where T : IInputElementBuilder
        {
            var focus = value ? HTMLATTRIBUTE.AUTOFOCUS : string.Empty;
            inputElementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.AUTOFOCUS, focus);
            return inputElementBuilder;
        }

       

      


    }
}
