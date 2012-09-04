namespace FluentHtml
{
    public class SubmitButton : ISubmitButton
    {
        private TagBuilder builder;

        public SubmitButton(string name)
        {
            builder = new TagBuilder(HTMLTAG.INPUT);
            this.Name(name).ID(name);
            builder.MergeAttribute(HTMLATTRIBUTE.TYPE, HTMLATTRIBUTE.SUBMIT);
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