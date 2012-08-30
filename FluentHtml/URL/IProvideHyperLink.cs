using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FluentHtml
{
    public interface IProvideHyperLink
    {
        Uri GetRelativeUri<TController>(Expression<Action<TController>> methodExpression);
    }
}
