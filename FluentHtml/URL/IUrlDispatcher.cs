using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentHtml
{
    public interface IUrlDispatcher
    {
        Tuple<string, IDictionary<string, object>> Dispatch<TController>(Expression<Action<TController>> methodExpression);
    }
}