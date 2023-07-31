using OpenQA.Selenium;
using Test_Framework.Tests;

namespace Test_Framework.Pages
{
    internal class OpenAccPage : Headr_Section
    {
        public OpenAccPage(IWebDriver driver) : base(driver) { }

        private const string CUSTOMER_FIELD_XPATH = "//option[@ng-repeat='cust in Customers' and text()='CreateNewUser AQA Last AQA']";
        private const string CURRENCY_FIELD_XPATH = "//option[@value='Dollar']";
        private const string PTOCES_BUTTON_XPATH = "//button[@type='submit' and @value='']";

        public OpenAccPage SelectCustomerInField()
        {
            WaitForElementToBeClickable(CUSTOMER_FIELD_XPATH);
            ClickElement(CUSTOMER_FIELD_XPATH);
            return this;
        }

        public OpenAccPage SelectCurrencyInField()
        {
            WaitForElementToBeClickable(CURRENCY_FIELD_XPATH);
            ClickElement(CURRENCY_FIELD_XPATH);
            return this;
        }

        public OpenAccPage ClickProcessButton()
        {
            WaitForElementToBeClickable(PTOCES_BUTTON_XPATH);
            ClickElement(PTOCES_BUTTON_XPATH);
            return this;
        }

        public OpenAccPage OpenAccount()
        {
            SelectCurrencyInField();
            SelectCustomerInField();
            ClickProcessButton();
            return this;
        }

        public override OpenAccPage OpenPageURL()
        {
            driver.Navigate().GoToUrl(SiteURLs.URL_Open_Account);
            return this;
        }
    }
}

