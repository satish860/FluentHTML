using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentHtml
{
    public interface IElementBuilder
    {
        TagBuilder Html { get; }
    }
}
