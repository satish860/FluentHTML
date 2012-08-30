using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHtml
{
    public class SubmitButton : ISubmitButton
    {
        TagBuilder builder;
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
