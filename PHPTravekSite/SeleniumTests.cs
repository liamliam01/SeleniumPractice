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
using OpenQA.Selenium.Firefox;

namespace PHPTravekSite
{

    namespace SeleniumTests
    {
        [Parallelizable]
        [TestFixture(typeof(InternetExplorerDriver))]
        [TestFixture(typeof(ChromeDriver))]
        [TestFixture(typeof(FirefoxDriver))]
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

                
                  
                 //public void WaitForElementLoad(By by, int timeoutInSeconds)
                 //{
                 //    if (timeoutInSeconds > 0)
                 //    {
                 //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                 //        wait.Until(ExpectedConditions.ElementIsVisible(by));
                 //    }
                 //}
                 driver.Navigate().GoToUrl("http://www.phptravels.net");


                IWebElement myAccount = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/ul/li[2]"));
                Thread.Sleep(100);
                myAccount.Click();

                IWebElement login = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/ul/li[2]/ul/li[1]/a"));
                Thread.Sleep(1000);
                login.Click();

                Thread.Sleep(1000);
               
                IWebElement email = driver.FindElement(By.Name("username"));


                email.Click();
                email.SendKeys("user@phptravels.com");

                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("demouser");

                IWebElement btnLogin = driver.FindElement(By.XPath("//*[@id=\"loginfrm\"]/div[4]/button"));
                btnLogin.Click();

                Thread.Sleep(2000);

                string nameConfirm = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[1]/h3")).Text;
                Assert.IsTrue(nameConfirm.Contains("Hi, John Smith"), nameConfirm + "not found");
                Console.Write("user welcome is found, login successful");

                Thread.Sleep(1000);

                driver.Close();

            }
        }
    }






}







