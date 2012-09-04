using CsQuery;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentHtmlExtensionTest
    {
        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_Html_back()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.TextBoxFor<Customer>(p => p.Name).Disabled(true).Class("Required").ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("Name");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be("text");
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_Password()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.PasswordFor<Customer>(p => p.Name).ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("Name");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.PASSWORD);
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_CheckBox()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.CheckBoxFor<Customer>(p => p.IsChecked).ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("IsChecked");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.CHECKBOX);
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_RadioButton()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.RadioButtonFor<Customer>(p => p.IsChecked).ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.RADIO);
        }

        [Test]
        public void Should_be_able_to_Generate_a_Reset_Button()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.ResetButton("SomeName").ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.RESET);
        }

        [Test]
        public void Should_be_able_to_Generate_a_Submit_Button()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string submitButton = htmlhelper.Submit("SomeName").ToString();
            var cq = CQ.Create(submitButton);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.SUBMIT);
        }

        [Test]
        public void Should_be_able_to_Generate_a_File_Input_Button()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string FileInput = htmlhelper.FileFor(P => P.fileFormat).ToString();
            var cq = CQ.Create(FileInput);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.File);
        }

        [Test]
        public void Should_be_able_to_Generate_a_Hidden_Field_With_Model_And_Property()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string FileInput = htmlhelper.Hidden(P => P.Name).ToString();
            var cq = CQ.Create(FileInput);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.HIDDEN);
        }

        [Test]
        public void Should_be_able_to_Create_A_Tag_with_the_Link()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            htmlhelper.Request = new HttpRequestMessage();
            htmlhelper.Request.RequestUri = new Uri("http://localhost/api/home");
            HttpConfiguration configuration = new HttpConfiguration();
            htmlhelper.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;
            htmlhelper.Request.AddDefaultRoute();
            string htmlanchortag = htmlhelper.Action<HomeController>(p => p.Get()).ToString();
            var cq = CQ.Create(htmlanchortag);
            cq.Attr(HTMLATTRIBUTE.HREF).Should().Be("/api/home");
        }
    }
}