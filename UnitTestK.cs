using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


using System;

namespace SeleniumUITest
{
    [TestClass]
    public class UnitTestK
    {
        [TestMethod]
        public void TestDeleteMovieAsMember()
        {
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);

            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("AwJie");
            webDriver.FindElement(passwordBar).SendKeys("password2");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement movieButton = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[2]/a"));
            movieButton.Click();

            IWebElement deleteButton = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/tbody/tr[3]/td[8]/a"));
            deleteButton.Click();

            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();


            IWebElement actualResult = webDriver.FindElement(By.XPath("//h1[text()='Forbidden']"));

            Assert.IsTrue(actualResult.Text.Equals("Forbidden"));

            webDriver.Quit();
        }
    }
}