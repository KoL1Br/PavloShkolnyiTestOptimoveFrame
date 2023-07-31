using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Framework.Tests
{

    internal class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public virtual void BeforeEachTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected virtual void TearDown()
        {
            driver.Close();
        }

    }
}
