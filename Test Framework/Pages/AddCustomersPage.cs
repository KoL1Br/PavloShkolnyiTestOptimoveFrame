using OpenQA.Selenium;
using Test_Framework.Models;
using Test_Framework.Tests;

namespace Test_Framework.Pages
{
    internal class AddCustomersPage : Headr_Section
    {
        public AddCustomersPage(IWebDriver driver) : base(driver) { }
        private const string FIRST_NAME_XPATH = "//input[@ng-model='fName']";
        private const string LAST_NAME_XPATH = "//input[@ng-model='lName']";
        private const string POST_CODE_XPATH = "//input[@ng-model='postCd']";
        private const string BUTTON_CUSTOMER_XPATH = "//button[@class='btn btn-default']";

        public override AddCustomersPage OpenPageURL()
        {
            driver.Navigate().GoToUrl(SiteURLs.URL_Add_Customer);
            return this;
        }

        public AddCustomersPage AddCustomer(CustomerModel customerModel)
        {
            SetText(FIRST_NAME_XPATH, customerModel.FirstName);
            SetText(LAST_NAME_XPATH, customerModel.LastName);
            SetText(POST_CODE_XPATH, customerModel.PostCode);

            var buttonAddCustomer = WaitForElementToBeClickable(BUTTON_CUSTOMER_XPATH);
            buttonAddCustomer.Click();

            return this;
        }
    }
}
