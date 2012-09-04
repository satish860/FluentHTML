using CsQuery;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace FluentHtml.Test
{
    [TestFixture]
    public class CheckBoxExtensionTest
    {
        [Test]
        public void Should_be_able_to_generate_the_Checkbox_with_the_Id_and_Name()
        {
            ICheckboxBuilder checkbox = new CheckBoxBuilder("Name", HTMLATTRIBUTE.CHECKBOX);
            var cqquery = CQ.Create(checkbox.ToString());
            cqquery.Attr(HTMLATTRIBUTE.NAME).Should().Be("Name");
            cqquery.Attr(HTMLATTRIBUTE.ID).Should().Be("Name");
        }

        [Test]
        public void Should_be_able_Generate_the_Checkbox_With_Checked()
        {
            ICheckboxBuilder checkbox = new CheckBoxBuilder("Name", HTMLATTRIBUTE.CHECKBOX)
                                              .Checked(true);
            var cqquery = CQ.Create(checkbox.ToString());
            cqquery.Attr(HTMLATTRIBUTE.CHECKED).Should().Be("checked");
        }

        //Will come later
        [Test]
        public void Should_be_able_to_Generate_Without_Checked()
        {
            ICheckboxBuilder checkbox = new CheckBoxBuilder("Name", HTMLATTRIBUTE.CHECKBOX)
            .Checked(false);
            var cqquery = CQ.Create(checkbox.ToString());
            cqquery.Select(p => p.Checked).First().Should().BeFalse();
        }
    }
}