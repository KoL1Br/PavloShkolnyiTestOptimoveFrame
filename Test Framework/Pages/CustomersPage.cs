using OpenQA.Selenium;
using Test_Framework.Tests;

namespace Test_Framework.Pages
{
    internal class CustomersPage : Headr_Section
    {
        private static string DELETE_CUSTOMER_BUTTON_XPATH(string userName) => $"//tr[@class='ng-scope'][td[text()='{userName}']]/td/button[@ng-click='deleteCust(cust)']";
        private const string FIELD_XPATH = "//input[@placeholder='Search Customer' and @ng-model='searchCustomer']\r\n";
        private static string CUSTOMER_XPATH(string userID) => $"//tr[.//td[text()='CreateNewUser AQA'] and .//td[text()='Last AQA'] and .//td[text()='123456'] and .//td/span[text()='{userID} ']]";
        public CustomersPage(IWebDriver driver) : base(driver) { }

        public CustomersPage DeleteUser(string userName)
        {
            WaitForElementToBeClickable(DELETE_CUSTOMER_BUTTON_XPATH(userName))
                .Click();
            return this;
        }

        public override CustomersPage OpenPageURL()
        {
            driver
                .Navigate()
                .GoToUrl(SiteURLs.URL_Customers_List);
            return this;
        }

        public CustomersPage SetTextInFIeld(string wordForSearch)
        {
            SetText(FIELD_XPATH, wordForSearch);
            return this;
        }

        public bool UserIsNotDisplayd(string userid)
        {
            return IsElementNotDisplayed(CUSTOMER_XPATH(userid));
        }
        public bool UserIsDisplayd(string userid)
        {
            return IsElementDisplayed(CUSTOMER_XPATH(userid));
        }

    }
}
