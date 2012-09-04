using CsQuery;
using FluentAssertions;
using NUnit.Framework;

namespace FluentHtml.Test
{
    [TestFixture]
    public class FluentTextBoxTest
    {
        [Test]
        public void Should_be_able_to_Generate_Text_With_the_type_Text_box()
        {
            ITextBoxBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.TEXT).Value("Satish");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr("name").Should().Be("Name");
            cq.Val().Should().Be("Satish");
        }

        [Test]
        public void Should_be_able_to_Generate_the_Text_With_Disabled_and_ReadOnly_TextBox()
        {
            ITextBoxBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.TEXT).Value("Satish").Disabled(true).IsReadOnly(true);
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr("name").Should().Be("Name");
            cq.Attr("disabled").Should().Be("disabled");
            cq.Attr("readonly").Should().Be("readonly");
            cq.Val().Should().Be("Satish");
        }

        [Test]
        public void Should_be_able_to_Generate_the_Text_With_AutoComplete_and_AutoFoucs_TextBox()
        {
            ITextBoxBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.TEXT)
                .Value("Satish")
                .EnableAutoComplete(true)
                .AutoFocus(true);
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr("name").Should().Be("Name");
            cq.Attr("AutoFocus").Should().Be("autofocus");
            cq.Attr("autocomplete").Should().Be("on");
            cq.Val().Should().Be("Satish");
        }

        [Test]
        public void Should_be_able_to_Generate_the_TextBox_with_the_PlaceHolder()
        {
            ITextBoxBuilder textbox = new InputBuilder("Name", HTMLATTRIBUTE.TEXT).WithPlaceholder("SomeText");
            string htmlTextBox = textbox.ToString();
            var cq = CQ.Create(htmlTextBox);
            cq.Attr("name").Should().Be("Name");
            cq.Attr("placeholder").Should().Be("SomeText");
        }
    }
}