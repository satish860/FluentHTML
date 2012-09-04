namespace FluentHtml
{
    public static class ElementBuilderExtensions
    {
        public static T Name<T>(this T elementBuilder, string name) where T : IElementBuilder
        {
            elementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.NAME, name);
            return elementBuilder;
        }

        public static T ID<T>(this T elementBuilder, string id) where T : IElementBuilder
        {
            elementBuilder.Html.MergeAttribute(HTMLATTRIBUTE.ID, id);
            return elementBuilder;
        }

        public static T Class<T>(this T elementBuilder, string cssClass) where T : IElementBuilder
        {
            elementBuilder.Html.AddCssClass(cssClass);
            return elementBuilder;
        }
    }
}