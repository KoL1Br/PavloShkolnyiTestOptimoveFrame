using FluentAssertions;
using NUnit.Framework;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    internal class CheckOpenPositionTest : BaseTest
    {
        [Test]
        public void CheckQAPositionIsDisplayed()
        {
            var companyPage = new CompanyPage(driver).OpenPageURL();
            companyPage
                .OpenOfficesDropDownMenu()
                .SelectOficesUKR();

            companyPage
                .PositionIsDisplayd("QA Automation Engineer")
                .Should()
                .BeTrue("Position QA Automation UKR is displayed");
        }
    }
}
