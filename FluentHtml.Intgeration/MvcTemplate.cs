using RazorEngine.Templating;

namespace FluentHtml.Intgeration
{
    public class MvcTemplate<TModel> : TemplateBase<TModel>
    {
        public FluentHtmlHelper<TModel> HTML { get; set; }

        public MvcTemplate()
        {
            HTML = new FluentHtmlHelper<TModel>();
        }
    }
}