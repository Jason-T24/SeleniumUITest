﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System;

namespace SeleniumUITest
{
    [TestClass]
    public class UnitTestJ
    {
        [TestMethod]
        public void TestCreateMovieAsManager()
        {
            int waitingTime = 5000;
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);

            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");
            By titleBar = By.Name("Title");
            By directorBar = By.Name("Director");
            By durationBar = By.Name("Duration");
            By priceBar = By.Name("Price");
            By theaterBar = By.Name("Theater");


            webDriver.FindElement(userIdBar).SendKeys("JoonHoe");
            webDriver.FindElement(passwordBar).SendKeys("password0");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement createButton = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[3]/a"));
            createButton.Click();

            webDriver.FindElement(titleBar).SendKeys("Spider-Man: Homecoming");
            webDriver.FindElement(directorBar).SendKeys("Jon Watts");
            webDriver.FindElement(durationBar).SendKeys("2.22");
            webDriver.FindElement(priceBar).SendKeys("10");
            webDriver.FindElement(theaterBar).SendKeys("T16");

            IWebElement submitButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div[8]/div/input"));
            submitButton.Click();

            Thread.Sleep(waitingTime);

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("//div[@class='alert alert-success']"));

            Assert.IsTrue(actualResultTest.Text.Equals("Movie Created"));

            webDriver.Quit();
        }
    }
}