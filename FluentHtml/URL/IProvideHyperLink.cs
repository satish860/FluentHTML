using System;
using System.Linq.Expressions;

namespace FluentHtml
{
    public interface IProvideHyperLink
    {
        Uri GetRelativeUri<TController>(Expression<Action<TController>> methodExpression);
    }
}