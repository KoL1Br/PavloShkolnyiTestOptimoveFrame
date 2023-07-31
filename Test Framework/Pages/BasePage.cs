using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test_Framework.Pages
{
    internal abstract class BasePage
    {
        private readonly TimeSpan _defaultTimeToWait = TimeSpan.FromSeconds(10);
        protected static IWebDriver driver;
        public BasePage(IWebDriver Webdriver)
        {
            driver = Webdriver;
        }

        public IWebElement WaitForElementToBeClickable(string xpath, TimeSpan timeToWait = default)
        {
            var wait = new WebDriverWait(driver, timeToWait == default ? _defaultTimeToWait : timeToWait);

            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        public IWebElement WaitForElementToBeVisible(string xpath, TimeSpan timeToWait = default)
        {
            var wait = new WebDriverWait(driver, timeToWait == default ? _defaultTimeToWait : timeToWait);
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        }

        public BasePage ClickElement(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
            return this;
        }

        public string GetText(string xpath)
        {
            return driver.FindElement(By.XPath(xpath)).Text;
        }

        public bool IsElementDisplayed(string xpath)
        {
            var element = WaitForElementToBeVisible(xpath);
            return element.Displayed;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public virtual BasePage OpenPageURL()
        {
            return this;
        }

        public BasePage SetText(string xpath, string text)
        {
            var element = WaitForElementToBeVisible(xpath);
            element.Clear();
            element.SendKeys(text);
            return this;
        }

        public string GetPageUrl(TimeSpan timeToWait = default)
        {
            Thread.Sleep(1000);
            return driver.Url;
        }

        public string GetStartTextPopUpWindow()
        {
            IAlert alert = driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text.Substring(0, Math.Min(text.Length, 15));
        }

        public string GetAccNumberPopUpWindow()
        {
            IAlert alert = driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text.Substring(text.Length - 4);
        }
        public bool IsElementNotDisplayed(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}
