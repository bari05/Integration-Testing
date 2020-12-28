using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTesting
{
    [TestFixture]
    public class SISTesting
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(); ;
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSISTestingTest()
        {
            driver.Navigate().GoToUrl("https://sis.iutoic-dhaka.edu/login");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("170042005");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("password");
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Id("m_login_signin_submit")).Click();
            driver.FindElement(By.LinkText("Dashboard")).Click();
            driver.FindElement(By.XPath("//div[@id='kt_aside_menu']/ul/li[2]/a/span/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='kt_aside_menu']/ul/li[3]/a/span/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='kt_aside_menu']/ul/li[4]/a/span/span/span")).Click();
            driver.FindElement(By.LinkText("Result")).Click();
            driver.FindElement(By.LinkText("Smart Card")).Click();
            driver.FindElement(By.XPath("//div[@id='kt_aside_menu']/ul/li[7]/a/span/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='kt_header']/div[2]/div/div/div/span[3]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Sign\n                            Out')]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
