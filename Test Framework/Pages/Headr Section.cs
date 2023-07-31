using OpenQA.Selenium;

namespace Test_Framework.Pages
{
    internal class Headr_Section : BasePage
    {

        private string BUTTON_HOME_XPATH = "//button[@class='btn home']";
        public Headr_Section(IWebDriver driver) : base(driver) { }

        public HomePage ClickButtonHome()
        {
            var button = WaitForElementToBeClickable(BUTTON_HOME_XPATH);
            button.Click();
            return new HomePage(driver).OpenPageURL();
        }
    }
}
