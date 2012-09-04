namespace FluentHtml
{
    public class InputBuilder : ITextBoxBuilder
    {
        private TagBuilder builder;

        public InputBuilder(string name, string type)
        {
            builder = new TagBuilder(HTMLTAG.INPUT);
            this.Name(name).ID(name);
            builder.MergeAttribute(HTMLATTRIBUTE.TYPE, type);
        }

        public override string ToString()
        {
            string rawstring = builder.ToString(TagRenderMode.SelfClosing);
            var mvcHtmlString = new FluentHtmlString(rawstring);
            return mvcHtmlString.ToHtmlString();
        }

        public TagBuilder Html
        {
            get { return builder; }
        }
    }
}