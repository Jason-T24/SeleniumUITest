using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace SeleniumUITest
{
    [TestClass]
    public class UnitTestM
    {
        [TestMethod]
        public void TestDeleteMemberAsManager()
        {
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);

            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("JoonHoe");
            webDriver.FindElement(passwordBar).SendKeys("password0");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement memberButton = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[2]/a"));
            memberButton.Click();

            IWebElement deleteButton = webDriver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[6]/td[5]/a"));
            deleteButton.Click();

            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("//div[@class='alert alert-success']"));

            Assert.IsTrue(actualResultTest.Text.Equals("User Record Deleted"));

            webDriver.Quit();
        }
    }
}