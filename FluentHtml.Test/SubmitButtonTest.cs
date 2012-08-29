using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace FluentHtml.Test
{
    [TestFixture]
    public class SubmitButtonTest
    {
        [Test]
        public void Should_be_able_Generate_the_Input_tag_with_Submit_Tag()
        {
            ISubmitButton textbox = new SubmitButton("Name").Value("Satish");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr("name").Should().Be("Name");
            cq.Val().Should().Be("Satish");
        }
    }
}
