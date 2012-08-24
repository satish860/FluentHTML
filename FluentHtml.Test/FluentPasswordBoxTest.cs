using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using CsQuery;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentPasswordBoxTest
    {
        [Test]
        public void Should_be_able_to_Generate_the_Password_Box()
        {
            IInputElementBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.PASSWORD).Value("Satish");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.PASSWORD);
            cq.Val().Should().Be("Satish");
        }

        [Test]
        public void Should_be_able_to_add_the_Css_Class_to_the_Password_Box()
        {
            IInputElementBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.PASSWORD).Value("Satish");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.PASSWORD);
            cq.Attr(HTMLATTRIBUTE.ID).Should().Be("Name");
        }

        [Test]
        public void Should_be_able_to_add_Id_to_the_property_With_the_Generic_Name()
        {
            IInputElementBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.PASSWORD)
                .Class("cssclass");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.PASSWORD);
            cq.Attr(HTMLATTRIBUTE.CLASS).Should().Be("cssclass");
        }
    }
}
