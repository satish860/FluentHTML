using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;


namespace FluentHtml.Test
{
    [TestFixture]
    public class HyperLinkProviderTest
    {
        [Test]
        public void Should_be_able_to_Generate_Url_From_the_Routes()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/api/home");
            HttpConfiguration configuration = new HttpConfiguration();
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;
            request.AddDefaultRoute();
            IProvideHyperLink provideHyperLink = new HyperLinkProvider(request);
            Uri url = provideHyperLink.GetRelativeUri<HomeController>(p => p.Get());
            url.ToString().Should().Be("/api/home");
        }

        [Test]
        public void Should_be_able_to_Get_the_Controller_name()
        {
            IUrlDispatcher dispacther = new UrlDispatcher();
            var controllerName = dispacther.Dispatch<HomeController>(p => p.Get());
            controllerName.Item2["controller"].Should().Be("home");
        }

        [Test]
        public void Should_be_Extract_the_Parameters_and_the_Info_in_Dictionary()
        {
            IUrlDispatcher dispatcher = new UrlDispatcher();
            var parameterInfo = dispatcher.Dispatch<HomeController>(p => p.GetById(1));
            parameterInfo.Item2["id"].Should().Be("1");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Should_throw_an_exception_if_the_expression_is_not_a_Method()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost/api/home");
            HttpConfiguration configuration = new HttpConfiguration();
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;
            request.AddDefaultRoute();
            IProvideHyperLink provideHyperLink = new HyperLinkProvider(request);
            Expression<Action<object>> expressionWhichIsNotAMethodCall =
                _ => new object();
            Uri url = provideHyperLink.GetRelativeUri(expressionWhichIsNotAMethodCall);
        }
    }
}
