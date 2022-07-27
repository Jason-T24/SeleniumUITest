using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System;

namespace SeleniumUITest
{
    [TestClass]
    public class UnitTestI
    {
        [TestMethod]
        public void TestRegisterAnAccount()
        {
            int waitingTime = 5000;
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            ChromeDriver webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl(URL);

            IWebElement register = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[2]/a"));
            register.Click();

            By nameBar = By.Name("FullName");
            By emailBar = By.Name("Email");
            By userBar = By.Name("UserId");
            By passwordBar = By.Name("UserPw");
            By confirmBar = By.Name("UserPw2");

            webDriver.FindElement(nameBar).SendKeys("Tom Holland");
            webDriver.FindElement(emailBar).SendKeys("TomHolland@gmail.com");
            webDriver.FindElement(userBar).SendKeys("TomHolland");
            webDriver.FindElement(passwordBar).SendKeys("password4");
            webDriver.FindElement(confirmBar).SendKeys("password4");

            IWebElement registerButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div[7]/div/input"));
            registerButton.Click();

            Thread.Sleep(waitingTime);

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div[8]/div/div/text"));

            Assert.IsTrue(actualResultTest.Text.Equals("User Successfully Registered"));

            webDriver.Quit();

        }
    }
}