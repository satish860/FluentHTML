using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentHtml
{
    public class HtmlActionTag : IHyperMediaControlBuilder
    {
        private readonly string Link;
        private readonly TagBuilder tagbuilder;
        public HtmlActionTag(string link)
        {
            this.tagbuilder = new TagBuilder(HTMLTAG.ANCHOR);
            this.Link = link;
            this.Href(link);
        }

        public override string ToString()
        {
            string rawstring = tagbuilder.ToString(TagRenderMode.Normal);
            var mvcHtmlString = new FluentHtmlString(rawstring);
            return mvcHtmlString.ToHtmlString();
        }

        public string ProvideLink()
        {
            return this.Link;
        }

        public TagBuilder Html
        {
            get { return tagbuilder; }
        }
    }
}
