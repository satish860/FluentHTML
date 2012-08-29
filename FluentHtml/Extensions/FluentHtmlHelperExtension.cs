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
        public static IInputElementBuilder TextBoxFor<TModel>(this FluentHtmlHelper<TModel> helper,Expression<Func<TModel,Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name,HTMLATTRIBUTE.TEXT);
        }

        public static IInputElementBuilder PasswordFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.PASSWORD);
        }


        public static ICheckboxBuilder CheckBoxFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, bool>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new CheckBoxBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.CHECKBOX);
        }


        public static ICheckboxBuilder RadioButtonFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, bool>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new CheckBoxBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.RADIO);
        }

        public static IInputElementBuilder ResetButton(this FluentHtmlHelper helper)
        {
            return new InputBuilder("",HTMLATTRIBUTE.RESET);
        }

        public static ISubmitButton Submit(this FluentHtmlHelper helper,string name)
        {
            return new SubmitButton(name);
        }

        public static string Action<TController>(this FluentHtmlHelper helper, Expression<Action<TController>> action)
        {
            var memberExpression = action.Body as MethodCallExpression;
            return string.Empty;
        }
    }
}
