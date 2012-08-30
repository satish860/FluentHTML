﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentHtml
{
    public class FileInputBuilder : IFileInputBuilder
    {

        TagBuilder builder;
        public FileInputBuilder(string name, string type)
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
