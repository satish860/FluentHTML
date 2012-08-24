using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using FluentHtml;

namespace FluentHtml.Intgeration
{
    public class MvcTemplate<TModel>:TemplateBase<TModel>
    {
        public FluentHtmlHelper<TModel> HTML { get; set; }

        public MvcTemplate()
        {
            HTML = new FluentHtmlHelper<TModel>();
        }
    }
}
