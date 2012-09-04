using System;
using System.Linq.Expressions;

namespace FluentHtml
{
    public static class FluentHtmlHelperExtension
    {
        public static IInputElementBuilder TextBoxFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.TEXT);
        }

        public static IInputElementBuilder PasswordFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.PASSWORD);
        }

        public static IInputElementBuilder Hidden<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, Object>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new InputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.HIDDEN);
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

        public static IInputElementBuilder ResetButton(this FluentHtmlHelper helper, string name)
        {
            return new InputBuilder(name, HTMLATTRIBUTE.RESET);
        }

        public static ISubmitButton Submit(this FluentHtmlHelper helper, string name)
        {
            return new SubmitButton(name);
        }

        public static IFileInputBuilder FileFor<TModel>(this FluentHtmlHelper<TModel> helper, Expression<Func<TModel, byte[]>> Property)
        {
            var memberExpression = Property.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return new FileInputBuilder(memberExpression.Member.Name, HTMLATTRIBUTE.File);
        }

        public static IHyperMediaControlBuilder Action<TController>(this FluentHtmlHelper helper, Expression<Action<TController>> action)
        {
            IProvideHyperLink provideLink = new HyperLinkProvider(helper.Request);
            var Link = provideLink.GetRelativeUri(action);
            return new HtmlActionTag(Link.ToString());
        }
    }
}