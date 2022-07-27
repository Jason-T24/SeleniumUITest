﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace SeleniumUITest
{
    [TestClass]
    public class UnitTestG
    {
        [TestMethod]
        public void TestViewMovies()
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

            IWebElement movie = webDriver.FindElement(By.XPath("/html/body/div[1]/h2"));
            IWebElement MovieID = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[1]"));
            IWebElement title = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[2]"));
            IWebElement director = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[3]"));
            IWebElement dateTime = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[4]"));
            IWebElement duration = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[5]"));
            IWebElement price = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[6]"));
            IWebElement theater = webDriver.FindElement(By.XPath("/html/body/div[1]/div/table/thead/tr/th[7]"));

            Assert.IsTrue(movie.Text.Equals("Movies"));
            Assert.IsTrue(MovieID.Text.Equals("Movie ID"));
            Assert.IsTrue(title.Text.Equals("Title"));
            Assert.IsTrue(director.Text.Equals("Director"));
            Assert.IsTrue(dateTime.Text.Equals("Date/Time"));
            Assert.IsTrue(duration.Text.Equals("Duration"));
            Assert.IsTrue(price.Text.Equals("Price"));
            Assert.IsTrue(theater.Text.Equals("Theater"));

            webDriver.Quit();
        }
    }
}