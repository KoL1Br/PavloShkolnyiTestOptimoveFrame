using OpenQA.Selenium;

namespace TestFramework.Pages
{
    internal class CompanyPage : BasePage
    {
        public CompanyPage(IWebDriver driver) : base(driver) { }
        private const string COUNTRY_DROP_DOWN_XPATH = "//*[contains(text(),'Offices')]/following-sibling::*[contains(@class,'select--job')]";
        private const string UKRAINE_COUNTRY_XPATH = "//*[contains(text(),'Offices')]/following-sibling::*[contains(@class,'select--job')]//li[normalize-space()='UKR']";
        private static string POSITION_QA_UKR_XPATH(string position) => $"//*[contains(text(),'{position}')]";

        public CompanyPage OpenPageURL()
        {
            driver.Navigate().GoToUrl(ListUrl.URL_Home);
            return this;
        }
        public bool PositionIsDisplayd(string positionName)
        {
            return IsElementDisplayed(POSITION_QA_UKR_XPATH(positionName));
        }
        public CompanyPage SelectOficesUKR()
        {
            WaitForElementToBeClickable(UKRAINE_COUNTRY_XPATH).Click();
            return this;
        }
        public CompanyPage OpenOfficesDropDownMenu()
        {
            var button = SсrollToElement(COUNTRY_DROP_DOWN_XPATH);
            button.WaitForElementToBeVisible(COUNTRY_DROP_DOWN_XPATH).Click();
            return this;
        }
    }
}
