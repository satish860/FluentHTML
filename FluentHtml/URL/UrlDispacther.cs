using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentHtml
{
    public class UrlDispatcher : IUrlDispatcher
    {
        public Tuple<string, IDictionary<string, object>> Dispatch<TController>(Expression<Action<TController>> methodExpression)
        {
            var expression = methodExpression.Body as MethodCallExpression;
            if (expression == null)
                throw new ArgumentException("The expression should be a Method .The Code blocked supplied Should invoke a method for example x=>x.MethodName()", "methodName");
            IDictionary<string, object> routeValues = ExtractParameters(expression);
            if (routeValues == null)
                routeValues = new Dictionary<string, object>();
            var controllerType = expression.Method.ReflectedType.Name.ToLower().Replace("controller", "");
            routeValues["controller"] = controllerType;
            return Tuple.Create("DefaultApi", routeValues);
        }

        private IDictionary<string, object> ExtractParameters(MethodCallExpression methodExpression)
        {
            var routeValues = methodExpression.Method.GetParameters()
               .ToDictionary(p => p.Name, p => GetValue(methodExpression, p));
            return routeValues;
        }

        private static object GetValue(MethodCallExpression methodCallExp,
           ParameterInfo p)
        {
            var arg = methodCallExp.Arguments[p.Position];
            var lambda = Expression.Lambda(arg);
            return lambda.Compile().DynamicInvoke().ToString();
        }
    }
}