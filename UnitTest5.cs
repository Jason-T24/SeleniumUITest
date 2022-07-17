using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace FYPUITest
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void TestLoginIntoStephaniesAccount()
        {
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);

            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("Stephanie");
            webDriver.FindElement(passwordBar).SendKeys("password3");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[2]/li[1]/p"));
            Assert.IsTrue(actualResultTest.Text.Equals("Welcome Stephanie Yap"));

            webDriver.Quit();
        }
    }
}