using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentHtml
{
    public class FluentHtmlString:HtmlString
    {
        
       // public static readonly FluentHtmlString Empty = Create(String.Empty);

        private readonly string _value;

        public FluentHtmlString(string value)
            : base(value ?? String.Empty)
        {
            _value = value ?? String.Empty;
        }

        //public static FluentHtmlString Create(string value)
        //{
        //    return new FluentHtmlString(value);
        //}

        //public static bool IsNullOrEmpty(FluentHtmlString value)
        //{
        //    return (value == null || value._value.Length == 0);
        //}
    }
}
