using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using FluentHtml;
using CsQuery;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace FluentHtml.Intgeration
{
    [TestFixture]
    public class RazorTextBoxIntegeration
    {
        [Test]
        public void Should_be_able_Parse_the_RazorMVCtemplate_With_FluentTextboxHelper()
        {
            var templateConfiguration = new TemplateServiceConfiguration();
            templateConfiguration.BaseTemplateType = typeof(MvcTemplate<>);
            templateConfiguration.Namespaces.Add("FluentHtml");
            templateConfiguration.Namespaces.Add("FluentHtml.Intgeration");
            templateConfiguration.EncodedStringFactory = new RawStringFactory();
            using (var template = new TemplateService(templateConfiguration))
            {
                FluentHtmlHelper<Customer> HTML = new FluentHtmlHelper<Customer>();
                string inputTemplate = "@HTML.TextBoxFor(p => p.Name).Disabled(true);";
                string output = template.Parse(inputTemplate, new Customer());
                CQ.Create(output).Attr("name").Should().Be("Name");
            }
        }
    }
}
