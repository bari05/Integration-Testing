using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting
{
    class ITest
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Google Chrome.lnk");
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
        }
        [Test]
        public void test()
        {
            driver.Url = "https://sis.iutoic-dhaka.edu/login"; 
            IWebElement element = driver.FindElement(By.Name("username")); 
            element.SendKeys("170042005");
            
            IWebElement password = driver.FindElement(By.Name("password")); 
            password.SendKeys("password"); 
            driver.FindElement(By.Id("m_login_signin_submit")).Click();
            
            String at = driver.Title;
            String et = "Student Information System V2";

            if (at == et)
            {
                Console.WriteLine("Test Successful"); 
                IWebElement element2 = driver.FindElement(By.XPath("//*[@id='kt_aside_menu']/ul/li[2]/a/span/span/span")); 
                element2.Click();
            }
            else
            {
                Console.WriteLine("Unsuccessful");
            }
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

        }
}
