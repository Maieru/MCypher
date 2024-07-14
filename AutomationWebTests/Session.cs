using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationWebTests
{
    public class Session
    {
        public WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"D:\Selenium\Drivers";
        private string BaseUrl { get; set; } = "https://localhost:7001";

        [SetUp]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
			if (WebDriver != null)
			{
				WebDriver.Quit();
				WebDriver.Dispose();
			}
		}

        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();

            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
        }

    }
}