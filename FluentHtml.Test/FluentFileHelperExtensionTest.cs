using CsQuery;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentFileHelperExtensionTest
    {
        [Test]
        public void Should_be_able_to_take_the_Accept_Header_With_the_Comma_Seperated_Mime_Type()
        {
            IFileInputBuilder textbox = new FileInputBuilder("Name", HTMLATTRIBUTE.File)
                .Value("Satish").Accept("image/gif");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.File);
            cq.Attr("accept").Should().Be("image/gif");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(FormatException))]
        public void Should_throw_error_if_the_Mime_Type_is_Wrong()
        {
            IFileInputBuilder textbox = new FileInputBuilder("Name", HTMLATTRIBUTE.File)
                .Value("Satish").Accept(@"image\gif");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
        }

        [Test]
        public void Should_be_able_to_accept_the_Multiple_Type_With_Condition()
        {
            IFileInputBuilder textbox = new FileInputBuilder("Name", HTMLATTRIBUTE.File)
               .Value("Satish").Accept("image/gif").AllowMultipleFileUpload(true);
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be(HTMLATTRIBUTE.File);
            cq.Attr("multiple").Should().Be("multiple");
        }
    }
}