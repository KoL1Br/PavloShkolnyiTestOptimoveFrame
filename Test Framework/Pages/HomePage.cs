using OpenQA.Selenium;
using Test_Framework.Tests;

namespace Test_Framework.Pages
{
    internal class HomePage : Headr_Section
    {
        private string BUTTON_CUSTOMER_LOGIN_XPATH = "//button[text()=\"Customer Login\"]";
        private string BUTTON_BANK_MANAGER_LOGIN_XPATH = "//button[text()=\"Bank Manager Login\"]";

        public HomePage(IWebDriver driver) : base(driver) { }

        public override HomePage OpenPageURL()
        {
            driver.Navigate().GoToUrl(SiteURLs.URL_Home);
            return this;
        }

        public HomePage ClickButtonBankManagerLogin()
        {
            var button = WaitForElementToBeClickable(BUTTON_BANK_MANAGER_LOGIN_XPATH);
            button.Click();

            return this;
        }
        public HomePage ClickButtonCustomerLogin()
        {
            var button = WaitForElementToBeClickable(BUTTON_CUSTOMER_LOGIN_XPATH);

            button.Click();
            return this;
        }
    }
}
