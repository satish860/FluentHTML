using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentHtml;
using NUnit.Framework;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentHtmlExtensionTest
    {
        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_Html_back()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.TextBoxFor<Customer>(p => p.Name);
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("Name");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be("text");
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_Password()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.PasswordFor<Customer>(p => p.Name);
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("Name");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.PASSWORD);
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_CheckBox()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.CheckBoxFor<Customer>(p => p.IsChecked);
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.NAME).Should().Be("IsChecked");
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.CHECKBOX);
        }

        [Test]
        public void Should_be_able_to_pass_in_the_Model_and_Property_and_Get_The_RadioButton()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlTextBox = htmlhelper.RadioButtonFor<Customer>(p => p.IsChecked);
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.RADIO);
        }

        public void Should_be_able_to_Create_A_Tag_with_the_Link()
        {
            FluentHtmlHelper<Customer> htmlhelper = new FluentHtmlHelper<Customer>();
            string htmlanchortag = htmlhelper.Action<HomeController>(p => p.Get());
        }
    }
}
