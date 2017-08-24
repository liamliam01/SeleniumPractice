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
using System.IO;

namespace PHPTravekSite
{

    namespace SeleniumTests
    {
         [Parallelizable]
        [TestFixture(typeof(InternetExplorerDriver))]
        [TestFixture(typeof(ChromeDriver))]
        public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            public IWebDriver driver;
            public IWebElement element;

            [SetUp]
            public void CreateDriver()
            {
                this.driver = new TWebDriver();
            }

            [Test]
            public void BrowserSmokeTest()
            {
                driver.Navigate().GoToUrl("http://www.google.com/");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Bread" + Keys.Enter);

                IWebElement google = driver.FindElement(By.Id("logo"));

                driver.Quit();
            }

            [Test]

            public void LaunchSite()
            {
                driver.Navigate().GoToUrl("http://www.phptravels.net");

               
                IWebElement myAccount = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/ul/li[2]"));

                Thread.Sleep(1000);

                myAccount.Click();
                IWebElement login = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/ul/li[2]/ul/li[1]/a"));

                Thread.Sleep(10000);

                login.Click();

                


            }
        }
    }




}







