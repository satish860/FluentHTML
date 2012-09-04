using CsQuery;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentHtmlActionTest
    {
        [Test]
        public void Should_be_able_to_generate_Href_With_the_A_tag()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").Name("Name");
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr("name").Should().Be("Name");
            cq.Attr(HTMLATTRIBUTE.HREF).Should().Be("/api/app");
        }

        [Test]
        public void Should_provide_the_Text_in_the_value_tag()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").Name("Name").Text("Some Link");
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr("name").Should().Be("Name");
            cq.Document.FirstChild.InnerText.Should().Be("Some Link");
        }

        [Test]
        public void Should_be_able_to_Generate_the_target_for_the_Browser_to_open_in_new_Window()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").OpenInNewWindow();
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr(HTMLATTRIBUTE.Target).Should().Be(HTMLATTRIBUTE.BLANK);
        }

        [Test]
        public void Should_be_able_to_Generate_the_target_for_the_Browser_to_open_in_ParentWindow()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").OpenInParentWindow();
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr(HTMLATTRIBUTE.Target).Should().Be(HTMLATTRIBUTE.PARENT);
        }

        [Test]
        public void Should_be_able_to_Generate_the_target_for_the_Browser_to_open_in_TopWindow()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").OpenInTopWindow();
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr(HTMLATTRIBUTE.Target).Should().Be(HTMLATTRIBUTE.TOP);
        }

        [Test]
        public void Should_be_able_to_Generate_the_target_for_the_Browser_to_open_in_Frame()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").OpenInFrame("SomeID");
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr(HTMLATTRIBUTE.Target).Should().Be("SomeID");
        }

        [Test]
        public void Should_be_able_to_generate_the_rel_to_the_Link_from_Current_Context()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").Rel("next");
            string HTMLAnchorTag = control.ToString();
            var cq = CQ.Create(HTMLAnchorTag);
            cq.Attr(HTMLATTRIBUTE.REL).Should().Be("next");
        }

        [Test]
        public void Should_be_able_to_Generate_the_language_tag_with_The_A()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").AcceptedLanguage("en");
            string htmlTextBox = control.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.Language).Should().Be("en");
        }

        [Test]
        public void Should_be_able_to_Provide_the_valid_Mime_type()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").AcceptType("image/gif");
            string htmlTextBox = control.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr(HTMLATTRIBUTE.TYPE).Should().Be("image/gif");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(FormatException))]
        public void Should_be_able_to_Throw_error_if_the_invalid_Mime_Type()
        {
            IHyperMediaControlBuilder control = new HtmlActionTag("/api/app").AcceptType(@"image\gif");
            string htmlTextBox = control.ToString();
            var cq = CQ.Create(htmlTextBox);
        }
    }
}