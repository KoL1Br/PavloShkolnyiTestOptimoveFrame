using OpenQA.Selenium;
using Test_Framework.Tests;

namespace Test_Framework.Pages
{
    internal class BankManagerLoginPage : Headr_Section
    {
        public BankManagerLoginPage(IWebDriver driver) : base(driver) { }
        private const string HEADER_ADD_CUSTOMERS_XPATH = "//button[contains(@ng-click, 'addCust()')]";
        private const string HEADER_OPEN_ACCOUNT_XPATH = "//button[contains(@ng-click, 'openAccount()')]";
        private const string HEADER_CUSTOMERS_XPATH = "//button[contains(@ng-click, 'showCust()')]";

        public override BankManagerLoginPage OpenPageURL()
        {
            driver.Navigate().GoToUrl(SiteURLs.URL_Manager_Login);
            return this;
        }

        public BankManagerLoginPage ClickButtonAddCustomer()
        {
            var button = WaitForElementToBeClickable(HEADER_ADD_CUSTOMERS_XPATH);
            button.Click();
            return this;
        }

        public BankManagerLoginPage ClickButtonOpenAccount()
        {
            var button = WaitForElementToBeClickable(HEADER_OPEN_ACCOUNT_XPATH);
            button.Click();
            return this;
        }

        public BankManagerLoginPage ClickButtonCustomers()
        {
            var button = WaitForElementToBeClickable(HEADER_CUSTOMERS_XPATH);
            button.Click();
            return this;
        }
    }
}
