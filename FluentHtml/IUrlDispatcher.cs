using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FluentHtml
{
    public interface IUrlDispatcher
    {
        Tuple<string, IDictionary<string, object>> Dispatch<TController>(Expression<Action<TController>> methodExpression);
    }
}
