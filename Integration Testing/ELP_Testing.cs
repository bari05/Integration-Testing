using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTesting
{
    [TestFixture]
    public class ELP_Testing
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
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
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://elp.duetbd.org/");
            driver.FindElement(By.Id("login_username")).Clear();
            driver.FindElement(By.Id("login_username")).SendKeys("170042005");
            driver.FindElement(By.Id("login_password")).Clear();
            driver.FindElement(By.Id("login_password")).SendKeys("password");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("loginbtn")).Click();
            driver.FindElement(By.Id("action-menu-toggle-1")).Click();
            driver.FindElement(By.Id("actionmenuaction-2")).Click();
            driver.FindElement(By.XPath("//div[@id='nav-drawer']/nav/ul/li[6]/a/div/div/span[2]")).Click();
            driver.FindElement(By.XPath("//li[@id='module-4968']/div/div/div[2]/span/form/div/button")).Click();
            driver.FindElement(By.XPath("//img[@alt='Not completed: AI Agents. Select to mark as complete.']")).Click();
            driver.FindElement(By.Id("action-menu-toggle-1")).Click();
            driver.FindElement(By.Id("actionmenuaction-6")).Click();
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
