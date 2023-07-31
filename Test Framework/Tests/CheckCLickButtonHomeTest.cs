using FluentAssertions;
using NUnit.Framework;
using Test_Framework.Pages;

namespace Test_Framework.Tests
{
    internal class CheckCLickButtonHomeTest : BaseTest
    {
        [Test]
        public void CheckButtonHome()
        {
            var homePage = new BankManagerLoginPage(driver).OpenPageURL();
            homePage.ClickButtonHome();

            homePage.GetPageUrl().Should().BeEquivalentTo(SiteURLs.URL_Home, "home button was clicked.");
        }
    }
}
