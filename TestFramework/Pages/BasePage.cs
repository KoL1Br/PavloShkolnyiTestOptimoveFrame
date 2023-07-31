using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TestFramework.Pages
{
    internal class BasePage
    {
        private readonly TimeSpan _defaultTimeToWait = TimeSpan.FromSeconds(10);
        protected static IWebDriver driver;
        public BasePage(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }

        public IWebElement WaitForElementToBeVisible(string xpath, TimeSpan timeToWait = default)
        {
            var wait = new WebDriverWait(driver, timeToWait == default ? _defaultTimeToWait : timeToWait);
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        }
        public IWebElement WaitForElementToBeClickable(string xpath, TimeSpan timeToWait = default)
        {
            var wait = new WebDriverWait(driver, timeToWait == default ? _defaultTimeToWait : timeToWait);

            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        public bool IsElementDisplayed(string xpath)
        {
            var element = WaitForElementToBeVisible(xpath);
            return element.Displayed;
        }
        public BasePage SсrollToElement(string xpathElement)
        {
            var elemetToSearch = driver.FindElement(By.XPath(xpathElement));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true); window.scrollBy(0, -100);", elemetToSearch);
            Thread.Sleep(2000);
            //thred sleep becouse sometimes drop down menu fallen
            return this;
        }
    }
}

