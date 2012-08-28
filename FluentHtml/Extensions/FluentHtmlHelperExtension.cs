using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentHtml
{
    public static class FluentHtmlHelperExtension
    {
        public static string TextBoxFor<TModel>(this FluentHtmlHelper<TModel> helper,Expression<Func<TModel,Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name,HTMLATTRIBUTE.TEXT).ToString();
        }

        public static string PasswordFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.PASSWORD).ToString();
        }


        public static string CheckBoxFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, bool>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new CheckBoxBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.CHECKBOX).ToString();
        }


        public static string RadioButtonFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, bool>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new CheckBoxBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.RADIO).ToString();
        }

        public static string Action<TController>(this FluentHtmlHelper helper, Expression<Action<TController>> action)
        {
            var memberExpression = action.Body as MethodCallExpression;
            return string.Empty;
        }
    }
}
