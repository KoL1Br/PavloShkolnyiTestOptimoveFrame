using FluentAssertions;
using NUnit.Framework;
using Test_Framework.Pages;

namespace Test_Framework.Tests
{
    internal class CheckCustomerLoginTest : BaseTest
    {
        [Test]
        public void Test()
        {
            var homePage = new HomePage(driver).OpenPageURL();
            homePage.ClickButtonCustomerLogin();

            homePage
            .GetPageUrl()
            .Should()
            .BeEquivalentTo(SiteURLs.URL_Customer_Login, "CustomerLogin button was clicked.");
        }
    }
}
