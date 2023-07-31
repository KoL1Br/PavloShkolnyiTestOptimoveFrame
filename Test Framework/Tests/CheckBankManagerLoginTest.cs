using FluentAssertions;
using NUnit.Framework;
using Test_Framework.Pages;

namespace Test_Framework.Tests
{
    internal class CheckBankManagerLoginTest : BaseTest
    {
        [Test]
        public void CheckBankManagerLogin()
        {
            var homePage = new HomePage(driver).OpenPageURL();

            homePage.ClickButtonBankManagerLogin();

            homePage
            .GetPageUrl()
            .Should()
            .BeEquivalentTo(SiteURLs.URL_Manager_Login, "BankManagerLogin button was clicked.");
        }
    }
}
