using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FluentHtml
{

    public class FluentHtmlHelper
    {
        public virtual HttpRequestMessage Request { get; set; }
    }

    public class FluentHtmlHelper<TModel> : FluentHtmlHelper
    {
        public FluentHtmlHelper()
        {

        }

        public TModel Model { get; set; }

        

    }
}
