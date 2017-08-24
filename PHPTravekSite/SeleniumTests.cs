using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace PHPTravekSite
{

    namespace SeleniumTests
    {
        // [Parallelizable]
        [TestFixture(typeof(InternetExplorerDriver))]
        [TestFixture(typeof(ChromeDriver))]
        public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            public IWebDriver driver;

            [SetUp]
            public void CreateDriver()
            {
                this.driver = new TWebDriver();
            }

            [Test]
            public void GoogleTest()
            {
                driver.Navigate().GoToUrl("http://www.google.com/");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Bread" + Keys.Enter);

                Assert.AreEqual("bread - Google Search", driver.Title);

                driver.Quit();
            }
        }
    }




}







